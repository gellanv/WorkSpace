using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WorkSpace.Helpers;
using WorkSpace.Models;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;

        public IdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
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