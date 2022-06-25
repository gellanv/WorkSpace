using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpace.Models;

namespace WorkSpace.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class BlocksController : ControllerBase
    //{
    //    private readonly WorkSpaceContext _context;

    //    public BlocksController(WorkSpaceContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/Blocks
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Block>>> GetBlock()
    //    {
    //        return await _context.Block.ToListAsync();
    //    }

    //    // GET: api/Blocks/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Block>> GetBlock(int id)
    //    {
    //        var block = await _context.Block.FindAsync(id);

    //        if (block == null)
    //        {
    //            return NotFound();
    //        }

    //        return block;
    //    }

    //    // PUT: api/Blocks/5
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutBlock(int id, Block block)
    //    {
    //        if (id != block.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(block).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!BlockExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Blocks
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    public async Task<ActionResult<Block>> PostBlock(Block block)
    //    {
    //        _context.Block.Add(block);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetBlock", new { id = block.Id }, block);
    //    }

    //    // DELETE: api/Blocks/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteBlock(int id)
    //    {
    //        var block = await _context.Block.FindAsync(id);
    //        if (block == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Block.Remove(block);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool BlockExists(int id)
    //    {
    //        return _context.Block.Any(e => e.Id == id);
    //    }
    //}
}
