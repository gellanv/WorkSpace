using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
