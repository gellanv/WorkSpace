using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
using WorkSpace.Services;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    [Route("api/workspaces")]
    [ApiController]

    public class WorkSpaceController : BaseController
    {
        private readonly WorkSpaceService workSpaceService;
        private readonly IMapper mapper;


        public WorkSpaceController(WorkSpaceService _workSpaceService, IMapper _mapper)
        {
            this.workSpaceService = _workSpaceService;
            this.mapper = _mapper;
        }
        //viemodel - string name, dto - 
        [HttpPost]
        public async Task<IActionResult> CreateWorkSpace(string name)
        {
            //Массив воркспейсов(id, name)
            IEnumerable<WorkSpaceDTO> workSpaceDTOs = await workSpaceService.GetAllWorkSpace(UserId);
            IEnumerable<GetAllWorkSpaceResponse> getAllWorkSpaceResponses = mapper.Map<IEnumerable<GetAllWorkSpaceResponse>>(workSpaceDTOs);

            return Ok(getAllWorkSpaceResponses);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpace()
        {
            //Массив воркспейсов(id, name)
            IEnumerable<WorkSpaceDTO> workSpaceDTOs = await workSpaceService.GetAllWorkSpace(UserId);
            IEnumerable<GetAllWorkSpaceResponse> getAllWorkSpaceResponses = mapper.Map<IEnumerable<GetAllWorkSpaceResponse>>(workSpaceDTOs);
            
            return Ok(getAllWorkSpaceResponses);
        }

        // GET: api/workspaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetWorkSpaceById(int id)
        {
            //list pages(id, name, date)
            //return Object <GetWorkSpaceResponse>
            //response ActionResult 400 incorrect Id
            //response ActionResult 404 with such id was not found.
            return null;
        }

        // PUT: api/workspaces/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeWorkSpaceById(int id, object workSpace)
        {
            //update only name
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
