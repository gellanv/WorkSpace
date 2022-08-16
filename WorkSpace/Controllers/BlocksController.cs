using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : BaseController
    {

        private readonly IBlockService blockService;
        private readonly IMapper mapper;
        

        public BlocksController(IBlockService _blockService, IMapper _mapper)
        {
            this.blockService = _blockService;
            this.mapper = _mapper;
        }
        /// <summary>
        /// Add template
        /// </summary>
        /// <response code="200">Success</response>        
        [HttpPost("addTemplate")]
        public async Task<IActionResult> AddListTemplateBlocksById(int pageId,int templateId)
        {
            PageTemplateDTO pageTemplateDTO = await blockService.AddListTemplateBlocksById(UserId, pageId, templateId);

            AddListBlocksTemplateResponse pageTemplateResponse = mapper.Map<AddListBlocksTemplateResponse>(pageTemplateDTO);
            return Ok(pageTemplateResponse);
        }

        /// <summary>
        /// Delete Block by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // DELETE: api/block/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlockById(int id)
        {
            await blockService.DeleteBlockById(UserId, id);

            return Ok();
        }

        /// <summary>
        /// Create new block
        /// </summary>
        /// <response code="200">Success</response>        
        [HttpPost]
        public async Task<IActionResult> CreateBlock(CreateBlockRequest createBlockRequest)
        {
            BlockDTO blockDTO = mapper.Map<BlockDTO>(createBlockRequest);
            BlockDTO newBlockDTO = await blockService.CreateBlock(UserId, blockDTO);
            CreateBlockResponse createBlockResponse = mapper.Map<CreateBlockResponse>(newBlockDTO);
           
            return Ok(createBlockResponse);
        }

        /// <summary>
        /// Update block by Id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/block/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlockById(int id,UpdateBlockRequest updateBlockRequest)
        {
            UpdateBlockDTO updateBlockDTO = mapper.Map<UpdateBlockDTO>(updateBlockRequest);
            updateBlockDTO.Id = id;
            updateBlockDTO.UserId = UserId;
            UpdateBlockDTO updatetBlockDTO = await blockService.UpdateBlockById(updateBlockDTO);
            UpdateBlockResponse updateBlockResponse = mapper.Map<UpdateBlockResponse>(updatetBlockDTO);
            return Ok(updateBlockResponse);
        }

        /// <summary>
        /// change Block Title by id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/changeBlockTitle/5
        [HttpPut("updateBlockTitle/{id}")]
        public async Task<ActionResult> UpdateBlockTitleById(int id, UpdateBlockTitleRequest changeBlockTitleRequest)
        {
            UpdateBlockTitleDTO changeBlockTitleDTO = mapper.Map<UpdateBlockTitleDTO>(changeBlockTitleRequest);
            changeBlockTitleDTO.Id = id;
            changeBlockTitleDTO.UserId = UserId;
            UpdateBlockDTO updatetBlockDTO = await blockService.UpdateBlockTitleById(changeBlockTitleDTO);
            UpdateBlockResponse updateBlockResponse = mapper.Map<UpdateBlockResponse>(updatetBlockDTO);
            return Ok(updateBlockResponse);
        }
        /// <summary>
        /// change Block Style by id
        /// </summary>
        /// <response code="200">Success</response>       
        // PUT: api/changeBlockStyle/5
        [HttpPut("updateBlockStyle/{id}")]
        public async Task<ActionResult> UpdateBlockStyleById(int id, UpdateBlockStyleRequest updateBlockStyleRequest)
        {
            UpdateBlockStyleDTO updateBlockStyleDTO = mapper.Map<UpdateBlockStyleDTO>(updateBlockStyleRequest);
            updateBlockStyleDTO.Id = id;
            updateBlockStyleDTO.UserId = UserId;
            UpdateBlockDTO updatetBlockDTO = await blockService.UpdateBlockStyleById(updateBlockStyleDTO);
            UpdateBlockResponse updateBlockResponse = mapper.Map<UpdateBlockResponse>(updatetBlockDTO);
            return Ok(updateBlockResponse);
        }
        /// <summary>
        /// Make dublicate of block by Id 
        /// </summary>
        /// <response code="200">Success</response>
        // POST: api/block/duplicate/5
        [HttpPost("duplicate/{id}")]
        public async Task<IActionResult> DuplicateBlock(int id)
        {
            BlockDuplicateDTO blockDuplicateDTO = await blockService.DuplicateBlock(UserId, id);
            BlockDuplicateResponse blockDuplicateResponse = mapper.Map<BlockDuplicateResponse>(blockDuplicateDTO);
             
            return Ok(blockDuplicateResponse);
        }

    }
}
