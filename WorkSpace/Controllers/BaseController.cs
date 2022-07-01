using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkSpace.Controllers
{
    [ApiController]    
    [Authorize]
   
    public class BaseController : ControllerBase
    {
        public string UserId => this.User.Claims.Single(x => x.Type == "id").Value;
    }
}
