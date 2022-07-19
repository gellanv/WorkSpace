using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
using WorkSpace.Services;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    
    [Route("api/workspaces")]
    [ApiController]

    public class WorkSpaceController : BaseController
    {
        private readonly IWorkSpaceService workSpaceService;
        private readonly IMapper mapper;


        public WorkSpaceController(IWorkSpaceService _workSpaceService, IMapper _mapper)
        {
            this.workSpaceService = _workSpaceService;
            this.mapper = _mapper;
        }

        //viemodel - string name, dto - 
        [HttpPost]
        public async Task<IActionResult> CreateWorkSpace([FromBody] CreateWorkSpaceRequest createWorkSpaceRequest)
        {
            
            var workSpaceDTO = mapper.Map<WorkSpaceDTO>(createWorkSpaceRequest);
            workSpaceDTO.UserId = UserId;
            var newWorkSpaceDTO = await workSpaceService.CreateWorkSpace(workSpaceDTO);
            CreateWorkSpaceResponse createWorkSpaceResponse = mapper.Map<CreateWorkSpaceResponse>(newWorkSpaceDTO);
           
            return Ok(createWorkSpaceResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpaces()
        {
            //Массив воркспейсов(id, name)
            IEnumerable<WorkSpaceDTO> workSpaceDTOs = await workSpaceService.GetAllWorkSpace(UserId);
            IEnumerable<GetAllWorkSpaceResponse> getAllWorkSpaceResponses = mapper.Map<IEnumerable<GetAllWorkSpaceResponse>>(workSpaceDTOs);
            
            return Ok(getAllWorkSpaceResponses);
        }
        //приходит id,name
        // GET: api/workspaces/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkSpaceById(int id)
        {
            var workSpaceWithListPagesDTO = await workSpaceService.GetWorkSpaceByID(id,UserId);
            var ListPagesResponse = mapper.Map<GetWorkSpaceByIdResponse>(workSpaceWithListPagesDTO);

            return Ok(ListPagesResponse);
        }

        // GET: api/workspaces/trash
        [HttpGet("trash")]
        public async Task<IActionResult> GetListDeletedPages()
        {
            var listDeletedPages = await workSpaceService.GetListDeletedPages(UserId);
            var ListPagesResponse = mapper.Map<IEnumerable<GetWorkSpaceByIdResponse>>(listDeletedPages);

            return Ok(ListPagesResponse);
        }
        // GET: api/workspaces/favorite
        [HttpGet("favorite")]
        public async Task<IActionResult> GetListFavoritePages()
        {
            var listDeletedPages = await workSpaceService.GetListFavoritePages(UserId);
            var ListPagesResponse = mapper.Map<IEnumerable<GetWorkSpaceByIdResponse>>(listDeletedPages);

            return Ok(ListPagesResponse);
        }

        // PUT: api/workspaces/5
        [HttpPut("changeName/{id}")]
        public async Task<IActionResult> ChangeWorkSpaceNameById(int id, ChangeWorkSpaceNameRequest workSpaceRequest)
        {
            var workSpaceDTO = mapper.Map<WorkSpaceDTO>(workSpaceRequest);
            workSpaceDTO.Id = id;
            var workSpaceChangedName = await workSpaceService.ChangeNameWorkSpace(workSpaceDTO,UserId);

            var workSpaceResponse = mapper.Map<ChangeNameWorkSpaceResponse>(workSpaceChangedName);
            //update only name
            //response ActionResult OK 204
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return Ok(workSpaceResponse);
        }

        // DELETE: api/workspaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DellWorkSpaceById(int id)
        {
            await workSpaceService.DeleteWorkSpace(id,UserId);

            return Ok();
        }
    }
}
