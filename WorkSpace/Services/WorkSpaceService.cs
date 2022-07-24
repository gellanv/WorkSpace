using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using WorkSpace.Behaviors;
using WorkSpace.Behaviors.Interface;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;
using DataAnnotationValidator = System.ComponentModel.DataAnnotations.Validator;

namespace WorkSpace.Services
{
    public class WorkSpaceService : IWorkSpaceService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        readonly IValidation validation;
        public WorkSpaceService(IUnitOfWork _unitOfWork, IMapper _mapper, IValidation _validation)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
            this.validation = _validation;
        }

        public async Task<IEnumerable<WorkSpaceDTO>> GetAllWorkSpace(string userId)
        {
            IEnumerable<Models.WorkSpace> workSpaces = await unitOfWork.RepositoryWorkSpace.GetWorkSpaces(userId);
            IEnumerable<WorkSpaceDTO> workSpacesDTO = mapper.Map<IEnumerable<WorkSpaceDTO>>(workSpaces);

            return workSpacesDTO;
        }

        public async Task<WorkSpaceWithListPagesDTO> GetWorkSpaceByID(int workSpaceId, string userID)
        {
            validation.CheckId(workSpaceId);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(workSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace.UserId == userID)
            {
                IEnumerable<Page> listPages = await unitOfWork.RepositoryPage.GetListPagesNotDeleted(workSpaceId);

                WorkSpaceWithListPagesDTO workSpaceWithListPagesDTO = new WorkSpaceWithListPagesDTO();
                workSpaceWithListPagesDTO.Id = workSpaceId;
                workSpaceWithListPagesDTO.Name = workSpace.Name;
                workSpaceWithListPagesDTO.Pages = mapper.Map<IEnumerable<WorkSpaceWithListPagesDTO.PagesDTO>>(listPages);

                return workSpaceWithListPagesDTO;
            }
            else throw new Exception("No access");
        }

        public async Task<WorkSpaceDTO> CreateWorkSpace(WorkSpaceDTO createWorkSpaceDTO)
        {
            validation.CheckObjectForValid(createWorkSpaceDTO);
            Models.WorkSpace mapToWorkSpaceModel = mapper.Map<Models.WorkSpace>(createWorkSpaceDTO);
            mapToWorkSpaceModel.DateCreate = DateTime.Now;

            Models.WorkSpace AddNewWorkSpace = await unitOfWork.RepositoryWorkSpace.Create(mapToWorkSpaceModel);
            await unitOfWork.SaveAsync();
            WorkSpaceDTO newDTOWorkSpace = mapper.Map<WorkSpaceDTO>(AddNewWorkSpace);

            return newDTOWorkSpace;
        }

        public async Task<WorkSpaceDTO> ChangeNameWorkSpace(WorkSpaceDTO changeNameWorkSpaceDTO)
        {
            validation.CheckObjectForValid(changeNameWorkSpaceDTO);
            validation.CheckId(changeNameWorkSpaceDTO.Id);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(changeNameWorkSpaceDTO.Id);
            validation.CheckObjectForNull(workSpace);

            if (workSpace.UserId == changeNameWorkSpaceDTO.UserId)
            {
                workSpace.Name = changeNameWorkSpaceDTO.Name;
                unitOfWork.RepositoryWorkSpace.Update(workSpace);
                await unitOfWork.SaveAsync();
                WorkSpaceDTO workSpaceDTO = mapper.Map<WorkSpaceDTO>(workSpace);

                return workSpaceDTO;
            }
            else throw new Exception("No access");
        }

        public async Task DeleteWorkSpace(int workSpaceId, string userId)
        {
            validation.CheckId(workSpaceId);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(workSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace.UserId == userId)
            {
                unitOfWork.RepositoryWorkSpace.Delete(workSpace);
                await unitOfWork.SaveAsync();
            }
            else throw new Exception("No access");
        }

        
    }
}
