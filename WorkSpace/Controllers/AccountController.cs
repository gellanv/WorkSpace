using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/account")]
    [ApiController]

    public class AccountController : BaseController
    {
        readonly IAccountService accountService;
        readonly IMapper mapper;

        public AccountController(IAccountService _accountService, IMapper _mapper)
        {
            accountService = _accountService;
            mapper = _mapper;
        }

        /// <summary>
        /// Get user name
        /// </summary>
        /// <response code="200">Success</response> 
        // GET: api/account/username
        [HttpGet("username")]
        public async Task<IActionResult> GetUserName()
        {
            var name = await accountService.GetUserName(UserId);

            return new JsonResult(new { userName = name });
        }

        /// <summary>
        /// Get all user information
        /// </summary>
        /// <response code="200">Success</response> 
        // GET: api/account
        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            AccountDTO accountDTO = await accountService.GetAccount(UserId);
            GetAccountResponse getAccountResponse = mapper.Map<GetAccountResponse>(accountDTO);

            return Ok(getAccountResponse);
        }

        /// <summary>
        /// Change user information
        /// </summary>
        /// <response code="200">Success</response> 
        // PUT: api/account
        [HttpPut]
        public async Task<ActionResult> ChangeAccount(ChangeAccountRequest account)
        {
            //var accessToken = Request.Headers["Authorization"];
            AccountDTO accountDTO = mapper.Map<AccountDTO>(account);
            accountDTO.Id = UserId;
            accountDTO = await accountService.ChangeAccount(accountDTO);

            return Ok(accountDTO);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <response code="200">Success</response> 
        // PUT: api/account/password
        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest passwords)
        {
            var rez = await accountService.ChangePassword(UserId, passwords);

            return Ok(rez);
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <response code="200">Success</response> 
        // DELETE: api/account
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount()
        {
            await accountService.DeleteAccount(UserId);

            return Ok();
        }
    }
}
