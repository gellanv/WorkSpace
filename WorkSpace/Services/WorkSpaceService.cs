using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Mappings;
using WorkSpace.Models;
using WorkSpace.Repositories;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services
{
    public class WorkSpaceService : IWorkSpaceService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public WorkSpaceService(IUnitOfWork _unitOfWork, IMapper _mapper)
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

        public async Task<WorkSpaceDTO> CreateWorkSpace(WorkSpaceDTO createWorkSpaceDTO)
        {
            var mapToWorkSpaceModel = mapper.Map<Models.WorkSpace>(createWorkSpaceDTO);
            mapToWorkSpaceModel.DateCreate = DateTime.Now;


            var AddNewWorkSpace = await unitOfWork.RepositoryWorkSpace.Create(mapToWorkSpaceModel);
            await unitOfWork.SaveAsync();
            var newDTOWorkSpace = mapper.Map<WorkSpaceDTO>(AddNewWorkSpace);
           
            return newDTOWorkSpace;
        }

        public async Task<IEnumerable<WorkSpaceGetPagesDTO>> GetWorkSpaceListPagesByID(int workSpaceId)
        {
            
            var listPages = await unitOfWork.RepositoryWorkSpace.GetPages(workSpaceId);
            var listPagesDTOs = mapper.Map<IEnumerable<WorkSpaceGetPagesDTO>>(listPages);

            return listPagesDTOs;


        }

        public async Task<WorkSpaceDTO> ChangeNameWorkSpace(WorkSpaceDTO changeNameWorkSpaceDTO)
        {
            var modelWorkSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(changeNameWorkSpaceDTO.Id);
            modelWorkSpace.Name = changeNameWorkSpaceDTO.Name;

            unitOfWork.RepositoryWorkSpace.Update(modelWorkSpace);
            unitOfWork.RepositoryWorkSpace.Save();
            var DTO = mapper.Map<WorkSpaceDTO>(modelWorkSpace);
            
            return DTO;

        }

        public async Task/*<IActionResult>*/ DeleteWorkSpace(int workSpaceId)
        {
            if (workSpaceId > 0)
            {
                var workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(workSpaceId);
                if (workSpace != null)
                {
                    unitOfWork.RepositoryWorkSpace.Delete(workSpace);
                       await unitOfWork.SaveAsync();
                    //return OkResult;
                }
                else throw new Exception("такого id не существует");
            }
            else throw new Exception("нет id");
            
        }

        
    }
}
