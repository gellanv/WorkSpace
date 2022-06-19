using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkSpace.Controllers
{
    [Route("api/workspaces")]
    [ApiController]

    public class WorkSpaceController : Controller
    {
        //check JWT token from headlines for ALL points of controller

        // GET: api/workspaces
        [HttpGet]
        public async Task<ActionResult<IQueryable<Object>>> GetAllWorkSpace()
        {
            //return IQueryable<GetAllWorkSpaceResponse>
            return null;
        }

        // GET: api/workspaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetWorkSpaceById(int id)
        {
            //return Object <GetWorkSpaceResponse>
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }

        // PUT: api/workspaces/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeWorkSpaceById(int id)
        {
            //response ActionResult OK 204
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }

        // DELETE: api/workspaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DellWorkSpaceById(int id)
        {
            //response ActionResult 204 OK
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }
    }
}
