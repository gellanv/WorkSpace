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
        public async Task<IActionResult> GetAllWorkSpace()
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
            
            var listPages = await workSpaceService.GetWorkSpaceListPagesByID(id);
            var ListPagesResponse = mapper.Map<IEnumerable<GetWorkSpaceByIdResponse>>(listPages);
           
            //list pages(id, name, date)
            //return Object <GetWorkSpaceResponse>
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.

            return Ok(ListPagesResponse);
        }

        //Замена имени воркспейса - 1 параметр id-workspaca, 2 параметр - object workSpace без айди => workSpace.id= id;
        // PUT: api/workspaces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeWorkSpaceNameById(int id, ChangeWorkSpaceNameRequest workSpaceRequest)
        {
            var workSpaceDTO = mapper.Map<WorkSpaceDTO>(workSpaceRequest);
            workSpaceDTO.Id = id;
            var workSpaceChangedName = await workSpaceService.ChangeNameWorkSpace(workSpaceDTO);

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
            await workSpaceService.DeleteWorkSpace(id);
            //response ActionResult 204 OK
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return Ok();
        }
    }
}
