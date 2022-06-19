using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkSpace.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
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
        public async Task<IActionResult> LogIn (Object userInput)
        {
            //receive Object <UserRequest>
            //response JWT token
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
    }
}
