using System.Collections.Generic;
using System.Threading.Tasks;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IPageService
    {
        Task<PageDTO> GetPageById(int pageId);
        Task DeletePageById(int pageId);
        Task<ChangePageNameDTO> ChangePageNameById(ChangePageNameDTO changePageNameDTO);
        Task<PageDTO> CreatePage(PageDTO pageDTO);
        Task<PageDTO> DuplicatePage(int pageId);

        Task<PageDTO> AddRemoveFavouritesById(PageDTO addRemoveToFavouritesByIdDTO);
        Task<PageDTO> PushPullPageToTrashById(PageDTO trashPageDTO);
        Task<IEnumerable<WorkSpaceDTO>> GetListDeletedPages(string userId);
        Task<IEnumerable<WorkSpaceDTO>> GetListFavoritePages(string userId);

    }
}
