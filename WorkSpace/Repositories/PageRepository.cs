using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await context.Pages.Where(x => x.Id == id).Include(b => b.Blocks).ThenInclude(elem => elem.Elements).FirstOrDefaultAsync();
        }

        public async Task<PageDTO> GetPageDTOById(int id)
        {
            return await context.Pages
                                       .Where(x => x.Id == id)
                                       .Select(page => new PageDTO
                                       {
                                           Id = id,
                                           Name = page.Name,
                                           WorkSpaceId = page.WorkSpaceId,
                                           ListBlocks = page.Blocks
                                                .Select(block => new PageDTO.BlockDTO
                                                {
                                                    Id = block.Id,
                                                    Title = block.Title,
                                                    ListElements = block.Elements
                                                                           .Select(elem => new PageDTO.BlockDTO.ElementDTO
                                                                           {
                                                                               Id = elem.Id,
                                                                               ContentHtml = elem.ContentHtml
                                                                           }),
                                                })
                                       })

                                       .FirstOrDefaultAsync();

        }
        public async Task<Page> Create(Page page)
        {
            await context.Pages.AddAsync(page);
            return page;
        }

        public void Update(Page page)
        {
            context.Entry(page).State = EntityState.Modified;
        }

        public void Delete(Page page)
        {
            context.Pages.Remove(page);
        }

        public async Task<IEnumerable<Page>> GetListPagesDeleted(string userId)
        {
            List<Models.WorkSpace> workSpaceUser = await context.WorkSpaces.Where(x => x.UserId == userId).Include(p => p.Pages).ToListAsync();
            List<Page> listPage = new List<Page>();
            for (int i = 0; i < workSpaceUser.Count(); i++)
            {
                for (int j = 0; j < workSpaceUser[i].Pages.Count(); j++)
                {
                    if (workSpaceUser[i].Pages[j].Deleted == true)
                        listPage.Add(workSpaceUser[i].Pages[j]);
                }
            }

            return (listPage);
        }

        public async Task<IEnumerable<Page>> GetListFavoritePages(string userId)
        {
            List<Models.WorkSpace> workSpaceUser = await context.WorkSpaces.Where(x => x.UserId == userId).Include(p => p.Pages).ToListAsync();
            List<Page> listPage = new List<Page>();
            for (int i = 0; i < workSpaceUser.Count(); i++)
            {
                for (int j = 0; j < workSpaceUser[i].Pages.Count(); j++)
                {
                    if (workSpaceUser[i].Pages[j].Favourite == true)
                        listPage.Add(workSpaceUser[i].Pages[j]);
                }
            }

            return (listPage);
        }
        public async Task<IEnumerable<Page>> GetListPagesNotDeleted(int workSpaceId)
        {
            return await context.Pages.Where(x => x.WorkSpaceId == workSpaceId && x.Deleted == false).ToListAsync();

        }
    }
}
