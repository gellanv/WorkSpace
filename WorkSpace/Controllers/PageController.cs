using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
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

        /// <summary>
        /// Create new page
        /// </summary>
        /// <response code="200">Success</response>        
        [HttpPost]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageRequest createPageRequest)
        {
            PageDTO pageDTO = mapper.Map<PageDTO>(createPageRequest);
            PageDTO newPageDTO = await pageService.CreatePage(UserId, pageDTO);
            CreatePageResponse createPageResponse = mapper.Map<CreatePageResponse>(newPageDTO);

            return Ok(createPageResponse);
        }

        /// <summary>
        /// Get page by Id
        /// </summary>
        /// <response code="200">Success</response>        
        // GET: api/page/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPageById(int id)
        {
            PageDTO pageDTO = await pageService.GetPageById(UserId, id);
            GetPageByIdResponse pageResponse = mapper.Map<GetPageByIdResponse>(pageDTO);

            return Ok(pageResponse);
        }

        /// <summary>
        /// Change Page name by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/page/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangePageNameById(int id, PageRequest changePageNameRequest)
        {
            ChangePageNameDTO changePageNameDTO = mapper.Map<ChangePageNameDTO>(changePageNameRequest);
            changePageNameDTO.Id = id;
            ChangePageNameDTO pageChangedName = await pageService.ChangePageNameById(UserId, changePageNameDTO);
            ChangePageNameResponse pageResponse = mapper.Map<ChangePageNameResponse>(pageChangedName);

            return Ok(pageResponse);
        }

        /// <summary>
        /// Delete Page by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // DELETE: api/page/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePageById(int id)
        {
            await pageService.DeletePageById(UserId, id);

            return Ok();
        }

        /// <summary>
        /// Add or Remove page from list Favourites by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/page/AddToFavourite/5
        [HttpPut("AddToFavourite/{id}")]
        public async Task<ActionResult> AddRemoveToFavouritesById(int id)
        {
            await pageService.AddRemoveFavouritesById(UserId, id);   
            
            return Ok();
        }

        /// <summary>
        /// Add or Remove page from list Trash by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/page/PushPullPageToTrash/5
        [HttpPut("PushPullPageToTrash/{id}")]
        public async Task<ActionResult> PushPullPageToTrashById(int id)
        {
            await pageService.PushPullPageToTrashById(UserId, id);

            return Ok();
        }

        /// <summary>
        /// Make dublicate of page by Id (ПОКА НЕ РАБОТАЕТ, ИСПОЛЬЗУЕТ КОНТРОЛЛЕРЫ, КОТОРЫЕ ЕЩЕ НЕ РЕАЛИЗОВАНЫ)
        /// </summary>
        /// <response code="200">Success</response>       
        [HttpPost("duplicate/{id}")]
        public async Task<IActionResult> DuplicatePage(int id)
        {           
            PageDTO copyPage = await pageService.DuplicatePage(UserId, id);
            CreatePageResponse createPageResponse = mapper.Map<CreatePageResponse>(copyPage);

            return Ok(createPageResponse);
        }


        //// GET: api/workspaces/trash
        //[HttpGet("trash")]
        //public async Task<IActionResult> GetListDeletedPages()
        //{
        //    IEnumerable<WorkSpaceDTO> listDeletedPages = await workSpaceService.GetListDeletedPages(UserId);
        //    IEnumerable<GetWorkSpaceByIdResponse> ListPagesResponse = mapper.Map<IEnumerable<GetWorkSpaceByIdResponse>>(listDeletedPages);

        //    return Ok(ListPagesResponse);
        //}
        //// GET: api/workspaces/favorite
        //[HttpGet("favorite")]
        //public async Task<IActionResult> GetListFavoritePages()
        //{
        //    var listDeletedPages = await workSpaceService.GetListFavoritePages(UserId);
        //    var ListPagesResponse = mapper.Map<IEnumerable<GetWorkSpaceByIdResponse>>(listDeletedPages);

        //    return Ok(ListPagesResponse);
        //}
    }
}
