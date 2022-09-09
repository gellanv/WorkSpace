using System.Collections.Generic;
using System.Threading.Tasks;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IWorkSpaceService
    {
        Task<IEnumerable<WorkSpaceDTO>> GetAllWorkSpace(string userId);
        Task<WorkSpaceDTO> CreateWorkSpace(WorkSpaceDTO createWorkSpaceDTO);
        Task<WorkSpaceDTO> ChangeNameWorkSpace(WorkSpaceDTO changeNameWorkSpaceDTO);
        Task<WorkSpaceWithListPagesDTO> GetWorkSpaceByID(int workSpaceId, string userID);
        Task<WorkSpaceWithListPagesDTO> GetPersonalWorkSpace(string userID);
        Task DeleteWorkSpace(int workSpaceId, string userId);
    }
}
