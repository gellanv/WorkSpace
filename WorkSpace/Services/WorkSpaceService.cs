using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Mappings;
using WorkSpace.Repositories;
using WorkSpace.Services.Interface;

namespace WorkSpace.Services
{
    public class WorkSpaceService : IWorkSpaceService
    {
        readonly UnitOfWork unitOfWork;
        readonly IMapper mapper;

        public WorkSpaceService(UnitOfWork _unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }

        public async Task<IEnumerable<WorkSpaceDTO>> GetAllWorkSpace(string userId)
        {
            var workSpaces = await unitOfWork.RepositoryWorkSpace.GetWorkSpaces(userId);
            var workSpacesDTO = mapper.Map<IEnumerable<WorkSpaceDTO>>(workSpaces);

            return workSpacesDTO;
        }

        //public async Task<IEnumerable<WorkSpaceDTO>> GetWorkSpaces(string userId)
        //{
        //   return await unitOfWork.RepositoryWorkSpace.GetWorkSpaces(userId);
        //}
    }
}
