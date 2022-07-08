using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IPageService
    {
        Task<IEnumerable<BlocksElementsDTO>> GetBlocksElementsOfPageById(int pageId);
    }
}
