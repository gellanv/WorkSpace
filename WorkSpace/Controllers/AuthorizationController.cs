using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;

namespace WorkSpace.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthorizationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // POST: api/registration
        [HttpPost("registration")]
        public async Task<IActionResult> AddUser([FromBody] UserRegistrationRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));
            }
            var authResponse = await _identityService.RegistrationAsync(user);

            return Ok(authResponse);
        }

        // POST: api/login
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] UserLogInRequest user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));
            }
            var authResponse = await _identityService.LoginAsync(user);

            return Ok(authResponse);
        }

        // POST: api/login
        [HttpPost("logingoogle")]
        public async Task<IActionResult> LogInGoogle([FromBody] ExternalAuthDto externalAuthDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));
            }
            var authResponse = await _identityService.LoginGoogleAsync(externalAuthDto);

            return Ok(authResponse);
        }
    }
}
