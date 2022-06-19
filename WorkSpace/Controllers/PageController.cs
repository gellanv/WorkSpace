﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkSpace.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class PageController : Controller
    {
        //// GET: api/page
        //[HttpGet]
        //public async Task<ActionResult<IQueryable<Object>>> GetAllPagesByIdWorkSpace(int idWorkSpace)
        //{
        //    //return IQueryable<GetAllPagesResponse>
        //    return null;
        //}

        // GET: api/page/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetPageById(int id)
        {
            //return Object <GetPageResponse> with including All blocks
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }

        // PUT: api/page/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangePageById(int id)
        {
            //response ActionResult OK 204
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }

        // DELETE: api/page/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DelPageById(int id)
        {
            //response ActionResult 204 OK
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }
    }
}
