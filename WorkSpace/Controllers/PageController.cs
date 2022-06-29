using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class PageController : Controller
    {

        private IUnitOfWork unitOfWork;

        public PageController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

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
            //unitOfWork.RepositoryPage.GetList();
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
