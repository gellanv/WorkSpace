using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class BlockRepository : IRepositoryBlock
    {
        private readonly WorkSpaceContext context;

        public BlockRepository(WorkSpaceContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Block> GetList()
        {
            return context.Blocks.ToList();
        }
        public async Task<Template> GetTemplateById(int id)
        {
            return await context.Templates.Where(x => x.Id == id).Include(b => b.BlockTemplates).FirstOrDefaultAsync();
        }
        public Block Get(int id)
        {
            return context.Blocks.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<Block> Create(Block block)
        {
            await context.Blocks.AddAsync(block);
            return block;
        }
        public void Update(Block block)
        {
            context.Entry(block).State = EntityState.Modified;
        }
        public async Task<Block> GetBlockById(int id)
        {
            return await context.Blocks.Where(x => x.Id == id).Include(elem => elem.Elements).FirstOrDefaultAsync();
        }
        public void Delete(Block block)
        {
           context.Blocks.Remove(block);
        }
        

        
    }
}
