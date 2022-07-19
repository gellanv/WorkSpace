using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services.Interface
{
    public interface IWorkSpaceService
    {
        Task<IEnumerable<WorkSpaceDTO>> GetAllWorkSpace(string userId);
        Task<WorkSpaceDTO> CreateWorkSpace(WorkSpaceDTO createWorkSpaceDTO);
        Task<WorkSpaceDTO> ChangeNameWorkSpace(WorkSpaceDTO changeNameWorkSpaceDTO,string userId);
        Task<WorkSpaceWithListPagesDTO> GetWorkSpaceByID(int workSpaceId, string userID);
        Task DeleteWorkSpace(int workSpaceId,string userId);
        Task<IEnumerable<WorkSpaceDTO>> GetListDeletedPages(string userId);
        Task<IEnumerable<WorkSpaceDTO>> GetListFavoritePages(string userId);


    }
}
