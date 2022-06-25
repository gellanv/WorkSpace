using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkSpace.Helpers;
using WorkSpace.ViewModels.Request;

namespace WorkSpace.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private UserRequestLogIn tempUser = new UserRequestLogIn { Login = "admin", Password = "admin" };

        // POST: api/registration
        [HttpPost("registration")]
        public async Task<IActionResult> AddUser(Object userInput)
        {
            //receive Object <AddUserRequest>
            //response ActionResult OK 200
            return null;
        }

        // POST: api/login
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] UserRequestLogIn user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errorText = "Required fields username and password." });
            }
            else
            {
                var identity = GetIdentity(user);//вызов сервиса GetIdentity - переносим далее в сервис

                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name,                   
                };

                return Ok(response);
            }
            return null;
        }

        // POST: api/logout
        [HttpPost("logout")]
        public async Task<IActionResult> LogOut(Object userLogOut)
        {
            //receive Object <UserLogOut>
            //Destroid JWT token
            //response ActionResult OK 200
            return null;
        }



        private ClaimsIdentity GetIdentity(UserRequestLogIn user)
        {
            // user = GetUserRepository  Находим пользователя в БД вызывая метод в репозитории

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
