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

            //Что возвращать?
            return Ok();
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

            return Ok();
        }

        //// GET: api/Blocks
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Block>>> GetBlock()
        //{
        //    return await _context.Blocks.ToListAsync();
        //}

        //// GET: api/Blocks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Block>> GetBlock(int id)
        //{
        //    var block = await _context.Blocks.FindAsync(id);

        //    if (block == null)
        //    {
        //        return NotFound();
        //    }

        //    return block;
        //}

        //// PUT: api/Blocks/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBlock(int id, Block block)
        //{
        //    if (id != block.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(block).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BlockExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Blocks
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Block>> PostBlock(Block block)
        //{
        //    _context.Blocks.Add(block);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBlock", new { id = block.Id }, block);
        //}

        //// DELETE: api/Blocks/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBlock(int id)
        //{
        //    var block = await _context.Blocks.FindAsync(id);
        //    if (block == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Blocks.Remove(block);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BlockExists(int id)
        //{
        //    return _context.Blocks.Any(e => e.Id == id);
        //}
    }
}
