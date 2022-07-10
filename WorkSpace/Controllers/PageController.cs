using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class PageController : BaseController
    {

        private readonly IPageService pageService;
        private readonly IMapper mapper;

        public PageController(IPageService _pageService, IMapper _mapper)
        {
            this.pageService = _pageService;
            this.mapper = _mapper;
        }

        // PUT: api/page/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangePageById(int id, ChangePageNameRequest changePageNameRequest)
        {
            var changePageNameDTO = mapper.Map<ChangePageNameDTO>(changePageNameRequest);
            changePageNameDTO.Id = id;
            var pageChangedName = await pageService.ChangePageNameById(changePageNameDTO);
            var pageResponse = mapper.Map<ChangePageNameResponse>(pageChangedName);

            return Ok(pageResponse);
            //response ActionResult OK 204
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            
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
        public async Task<ActionResult> GetPageById(int id)
        {
            //list of blocks (id, title) + list of element

            //return Object <GetPageResponse> with including All blocks
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            var pageDTO = await pageService.GetPageById(id);
           // var pageResponse = mapper.Map<GetPageByIdResponse>(pageDTO); не могу мапнуть

            return Ok(pageDTO);
        }

        

        // DELETE: api/page/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePageById(int id)
        {
            //response ActionResult 204 OK
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            await pageService.GetPageById(id);

            return Ok();
        }
    }
}
