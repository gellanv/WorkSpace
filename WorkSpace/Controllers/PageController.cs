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

        [HttpPost("{pageId}")]
        public async Task<IActionResult> DuplicatePage(int pageId)
        {
            //var pageDTO = await pageService.GetPageById(pageId);
            var copyPage = await pageService.DuplicatePage(pageId);
            var createPageResponse = mapper.Map<CreatePageResponse>(copyPage);

            return Ok(createPageResponse);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageRequest createPageRequest)
        {
            var pageDTO = mapper.Map<PageDTO>(createPageRequest);
            var newPageDTO = await pageService.CreatePage(pageDTO);
            var createPageResponse = mapper.Map<CreatePageResponse>(newPageDTO);

            return Ok(createPageResponse);
        }



        // GET: api/page/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPageById(int id)
        {
            //list of blocks (id, title) + list of element

            //return Object <GetPageResponse> with including All blocks
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            var pageDTO = await pageService.GetPageById(id);
            var pageResponse = mapper.Map<GetPageByIdResponse>(pageDTO);

            return Ok(pageResponse);
        }

        

        // DELETE: api/page/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePageById(int id)
        {
            //response ActionResult 204 OK
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            await pageService.DeletePageById(id);

            return Ok();
        }
    }
}
