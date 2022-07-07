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
        public Block Get(int id)
        {
            return context.Blocks.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Create(Block block)
        {
            context.Blocks.Add(block);
        }
        public void Update(Block block)
        {
            context.Entry(block).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Block block = context.Blocks.Find(id);
            if (block != null)
                context.Blocks.Remove(block);
        }
        

        
    }
}
