using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories
{
    public class PageRepository : IRepositoryPage
    {
        private readonly WorkSpaceContext context;
        public PageRepository(WorkSpaceContext _context)
        {
            context = _context;
        }
        public IEnumerable<Page> GetList()
        {
            return context.Pages.ToList();
        }
        
        public async Task<IEnumerable<Block>> GetPageById(int id)
        {
            return await context.Blocks.Where(x => x.PageId == id).Include(u=>u.Elements).ToListAsync();
        }
        public void Create(Page page)
        {
            context.Pages.Add(page);
        }

        public void Update(Page page)
        {
            context.Entry(page).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Page page = context.Pages.Find(id);
            if (page != null)
                context.Pages.Remove(page);
        }
        



        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        

        Task<Page> IRepositoryPage.Create(Page page)
        {
            throw new NotImplementedException();
        }
    }
}
