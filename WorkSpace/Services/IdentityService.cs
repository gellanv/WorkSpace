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

        public async Task<UserRegistrationResponse> RegistrationAsync(UserRegistrationRequest user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return new UserRegistrationResponse
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
                return new UserRegistrationResponse
                {
                    Error = createUser.Errors.ToString()
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                { 
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),//для рефреш токена
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserRegistrationResponse
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                UserName= newUser.UserName
            };
        }
    }
}
