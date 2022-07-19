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

        public async Task<WorkSpaceWithListPagesDTO> GetWorkSpaceByID(int workSpaceId, string userID)
        {
            if (workSpaceId > 0)
            {

                var workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(workSpaceId);

                if (workSpace != null)
                {
                    if (workSpace.UserId == userID)
                    {
                        var listPages = await unitOfWork.RepositoryWorkSpace.GetListPagesNotDeleted(workSpaceId);

                        var workSpaceWithListPagesDTO = new WorkSpaceWithListPagesDTO();
                        workSpaceWithListPagesDTO.Id = workSpaceId;
                        workSpaceWithListPagesDTO.Name = workSpace.Name;
                        workSpaceWithListPagesDTO.Pages = mapper.Map<IEnumerable<WorkSpaceWithListPagesDTO.PagesDTO>>(listPages);

                        return workSpaceWithListPagesDTO;

                    }
                    else throw new Exception("нет доступа");

                }
                else throw new Exception("такого id нет в базе");

            }
            else throw new Exception("не верный id");

        }
        public async Task<IEnumerable<WorkSpaceDTO>> GetListDeletedPages(string userId)
        {
            var workSpaces = await unitOfWork.RepositoryWorkSpace.GetListPagesDeleted(userId);
            var workSpacesDTO = mapper.Map<IEnumerable<WorkSpaceDTO>>(workSpaces);

            return workSpacesDTO;
        }
        public async Task<IEnumerable<WorkSpaceDTO>> GetListFavoritePages(string userId)
        {
            var workSpaces = await unitOfWork.RepositoryWorkSpace.GetListPagesDeleted(userId);
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

        public async Task<WorkSpaceDTO> ChangeNameWorkSpace(WorkSpaceDTO changeNameWorkSpaceDTO, string userId)
        {
            if (changeNameWorkSpaceDTO.Id > 0)
            {
                var workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(changeNameWorkSpaceDTO.Id);

                if (workSpace != null)
                {
                    if (workSpace.UserId == userId)
                    {
                        workSpace.Name = changeNameWorkSpaceDTO.Name;

                        unitOfWork.RepositoryWorkSpace.Update(workSpace);
                        await unitOfWork.SaveAsync();
                        var DTO = mapper.Map<WorkSpaceDTO>(workSpace);

                        return DTO;
                    }
                    else throw new Exception("нет доступа");
                }
                else throw new Exception("такого id нет в базе");
            }
            else throw new Exception("не верный id");
        }

        public async Task DeleteWorkSpace(int workSpaceId, string userId)
        {
            if (workSpaceId > 0)
            {
                var workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(workSpaceId);
                
                    if (workSpace != null)
                    {
                        if (workSpace.UserId == userId)
                        {
                            unitOfWork.RepositoryWorkSpace.Delete(workSpace);
                            await unitOfWork.SaveAsync();
                        }
                        else throw new Exception("нет доступа");

                    }else throw new Exception("такого id нет в базе");


            }else throw new Exception("не верный id");


        }
    }
}
