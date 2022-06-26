using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkSpace.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/account")]
    [ApiController]
   
    public class AccountController : Controller
    {        
        // GET: api/account
        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {    
           return Ok();
        }

        
        // PUT: api/account/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Object>> PutAccount(int id, Object userUpdate)
        {            
            //return All date except password Object <GetAccountResponse>
            return null;
        }

        // PUT: api/account/5/password
        [HttpPut("{id}/password")]
        public async Task<IActionResult> PutPassword(int id, Object passwords)
        {
            //response ActionResult OK 200
            return null;
        }


        // DELETE: api/account
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {           
            //response ActionResult OK 200
            return null;
        }
    }
}
