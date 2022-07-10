using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Models;
using static WorkSpace.DTO.PageDTO;

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
        public async Task<Page> GetPageById(int id)
        {
            return await context.Pages.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PageDTO> GetPageDTOById(int id)
        {
            
            return await context.Pages
                                       .Where(x => x.Id == id)
                                       .Select(page=>new PageDTO
                                            {
                                             Id = id,
                                             Name = page.Name,
                                             ListBlocks=page.Blocks
                                                .Select(block => new BlockDTO
                                                 {
                                                     Id = block.Id,
                                                     Title = block.Title,
                                                     ListElements = block.Elements
                                                                           .Select(elem => new BlockDTO.ElementDTO
                                                                           {
                                                                               Id = elem.Id,
                                                                               ContentHtml = elem.ContentHtml
                                                                           }),
                                                 })
                                            })
                                       
                                       .FirstOrDefaultAsync();


            
            //return await context.Blocks
            //                            .Where(x => x.PageId == id)
            //                            .Select(block => new BlocksElementsDTO
            //                            {
            //                                Id = block.Id,
            //                                Title = block.Title,
            //                                Elements = block.Elements
            //                                .Select(elem => new BlocksElementsDTO.ElementDTO
            //                                {
            //                                    Id = elem.Id,
            //                                    ContentHtml = elem.ContentHtml
            //                                }),
            //                            })
            //                            .ToListAsync();
        }
        public void Create(Page page)
        {
            context.Pages.Add(page);
        }

        public void Update(Page page)
        {
            context.Entry(page).State = EntityState.Modified;
        }

        public void Delete(Page page)
        {
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
