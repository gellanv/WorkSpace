using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IPageService
    {
        Task<PageDTO> GetPageById(string UserId, int pageId);
        Task DeletePageById(string UserId, int pageId);
        Task<ChangePageNameDTO> ChangePageNameById(string UserId, ChangePageNameDTO changePageNameDTO);
        Task<PageDTO> CreatePage(string UserId, PageDTO pageDTO);
        Task<PageDTO> DuplicatePage(string UserId, int pageId);
        Task AddRemoveFavouritesById(string UserId, int id);
        Task PushPullPageToTrashById(string UserId, int id);
        Task<IEnumerable<PageDTO>> GetListDeletedPages(string userId);
        Task<IEnumerable<PageDTO>> GetListFavoritePages(string userId);
    }
}
