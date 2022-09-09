using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
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

        /// <summary>
        /// Create new WorkSpace
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">The Name field is required</response>
        /// <response code="500">The UserId field is required</response>
        // POST: api/workspaces
        [HttpPost]
        public async Task<IActionResult> CreateWorkSpace([FromBody] CreateWorkSpaceRequest createWorkSpaceRequest)
        {

            WorkSpaceDTO workSpaceDTO = mapper.Map<WorkSpaceDTO>(createWorkSpaceRequest);
            workSpaceDTO.UserId = UserId;
            WorkSpaceDTO newWorkSpaceDTO = await workSpaceService.CreateWorkSpace(workSpaceDTO);
            CreateWorkSpaceResponse createWorkSpaceResponse = mapper.Map<CreateWorkSpaceResponse>(newWorkSpaceDTO);

            return Ok(createWorkSpaceResponse);
        }

        /// <summary>
        /// Get all WorkSpaces
        /// </summary>
        /// <response code="200">Success</response> 
        // GET: api/workspaces
        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpaces()
        {
            //Массив воркспейсов(id, name)
            IEnumerable<WorkSpaceDTO> workSpaceDTOs = await workSpaceService.GetAllWorkSpace(UserId);
            IEnumerable<GetAllWorkSpaceResponse> getAllWorkSpaceResponses = mapper.Map<IEnumerable<GetAllWorkSpaceResponse>>(workSpaceDTOs);

            return Ok(getAllWorkSpaceResponses);
        }

        /// <summary>
        /// Get Personal WorkSpace
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Id isn't valid / The object wasn't found</response>
        // GET: api/workspaces/personal
        [HttpGet("personal")]
        public async Task<IActionResult> GetPersonalWorkSpace()
        {
            WorkSpaceWithListPagesDTO personalWorkSpaceWithListPagesDTO = await workSpaceService.GetPersonalWorkSpace(UserId);
            GetWorkSpaceByIdResponse personalWorkSpaceListPagesResponse = mapper.Map<GetWorkSpaceByIdResponse>(personalWorkSpaceWithListPagesDTO);

            return Ok(personalWorkSpaceListPagesResponse);
        }

        /// <summary>
        /// Get WorkSpace by id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Id isn't valid / The object wasn't found</response>
        // GET: api/workspaces/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkSpaceById(int id)
        {
            WorkSpaceWithListPagesDTO workSpaceWithListPagesDTO = await workSpaceService.GetWorkSpaceByID(id, UserId);
            GetWorkSpaceByIdResponse ListPagesResponse = mapper.Map<GetWorkSpaceByIdResponse>(workSpaceWithListPagesDTO);

            return Ok(ListPagesResponse);
        }

        /// <summary>
        /// Change WorkSpace name by Id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Id isn't valid / The object wasn't found /The name field is empty/ </response>
        // PUT: api/workspaces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeWorkSpaceNameById(int id, ChangeWorkSpaceNameRequest workSpaceRequest)
        {
            WorkSpaceDTO workSpaceDTO = mapper.Map<WorkSpaceDTO>(workSpaceRequest);
            workSpaceDTO.Id = id;
            workSpaceDTO.UserId = UserId;
            WorkSpaceDTO workSpaceChangedName = await workSpaceService.ChangeNameWorkSpace(workSpaceDTO);
            ChangeNameWorkSpaceResponse workSpaceResponse = mapper.Map<ChangeNameWorkSpaceResponse>(workSpaceChangedName);

            return Ok(workSpaceResponse);
        }

        /// <summary>
        /// Delete WorkSpace by Id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Id isn't valid / The object wasn't found</response>
        // DELETE: api/workspaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DellWorkSpaceById(int id)
        {
            await workSpaceService.DeleteWorkSpace(id, UserId);

            return Ok();
        }
    }
}
