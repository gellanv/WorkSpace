using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IBlockService
    {
        Task<PageTemplateDTO> AddListTemplateBlocksById(string UserId,int pageId, int templateId);
        Task DeleteBlockById(string UserId, int blockId);

        Task<BlockDTO> CreateBlock(string UserId, BlockDTO blockDTO);
        Task<UpdateBlockDTO> UpdateBlockById(UpdateBlockDTO updateBlockDTO);
        Task<UpdateBlockDTO> UpdateBlockTitleById(UpdateBlockTitleDTO changeBlockTitleDTO);
        Task<BlockDuplicateDTO> DuplicateBlock(string UserId,int id);
        Task<UpdateBlockDTO> UpdateBlockStyleById(UpdateBlockStyleDTO updateBlockStyleDTO);

    }
}
