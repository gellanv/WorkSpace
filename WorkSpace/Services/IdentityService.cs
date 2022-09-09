using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkSpace.Helpers;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork unitOfWork;
        public IdentityService(UserManager<User> userManager, IUnitOfWork _unitOfWork)
        {
            _userManager = userManager;
            unitOfWork = _unitOfWork;
        }

        public async Task<AuthenticationResponse> RegistrationAsync(UserRegistrationRequest user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return new AuthenticationResponse
                {
                    Error = "User with such email already exists"
                };
            }
            var newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            var createUser = await _userManager.CreateAsync(newUser, user.Password);
            if (!createUser.Succeeded)
            {
                return new AuthenticationResponse
                {
                    Error = createUser.Errors.ToString()
                };
            }

            Models.WorkSpace personalWorkSpaceModel = new Models.WorkSpace();
            personalWorkSpaceModel.DateCreate = DateTime.Now;
            personalWorkSpaceModel.Name = "Personal";
            personalWorkSpaceModel.UserId = newUser.Id;
            Models.WorkSpace addPersonalWorkSpace = await unitOfWork.RepositoryWorkSpace.Create(personalWorkSpaceModel);
            addPersonalWorkSpace.Personal = true;
            await unitOfWork.SaveAsync();

            return CreateToken(newUser.Id, newUser.Email, newUser.UserName);
        }

        public async Task<AuthenticationResponse> LoginAsync(UserLogInRequest user)
        {
            var _user = await _userManager.FindByEmailAsync(user.Email);
            if (_user == null)
            {
                return new AuthenticationResponse
                {
                    Error = "User does not exists"
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(_user, user.Password);
            if (!userHasValidPassword)
            {
                return new AuthenticationResponse
                {
                    Error = "User/password combination is wrong"
                };
            }

            return CreateToken(_user.Id, _user.Email, _user.UserName);
        }

        public async Task<AuthenticationResponse> LoginGoogleAsync(ExternalAuthDto externalAuthDto)
        {
            var payload = await VerifyGoogleToken(externalAuthDto);

            if (payload == null)
                throw new Exception("Invalid External Authentication.");

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new User { Email = payload.Email, UserName = payload.Email };
                    await _userManager.CreateAsync(user);
                    await _userManager.AddLoginAsync(user, info);
                    Models.WorkSpace personalWorkSpaceModel = new Models.WorkSpace();
                    personalWorkSpaceModel.DateCreate = DateTime.Now;
                    personalWorkSpaceModel.Name = "Personal";
                    personalWorkSpaceModel.UserId = user.Id;
                    Models.WorkSpace addPersonalWorkSpace = await unitOfWork.RepositoryWorkSpace.Create(personalWorkSpaceModel);
                    addPersonalWorkSpace.Personal = true;
                    await unitOfWork.SaveAsync();
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }
            if (user == null)
                throw new Exception("Invalid External Authentication.");

            AuthenticationResponse authenticationResponse = CreateToken(user.Id, user.Email, user.UserName);

            
            return authenticationResponse;
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { AuthOptions.ClientID }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.TokenID, settings);
                return payload;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid External Authentication.");
            }
        }


        private AuthenticationResponse CreateToken(string id, string email, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //для рефреш токена
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("id", id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResponse
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                UserName = userName
            };
        }
    }
}