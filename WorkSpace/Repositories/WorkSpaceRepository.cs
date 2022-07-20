using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class WorkSpaceRepository : IRepositoryWorkSpace
    {
        private readonly WorkSpaceContext context;

        public WorkSpaceRepository(WorkSpaceContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Models.WorkSpace>> GetWorkSpaces(string userId)
        {
            return await context.WorkSpaces.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Models.WorkSpace> GetWorkSpaceById(int workSpaceId)
        {
            return await context.WorkSpaces.Where(x => x.Id == workSpaceId).FirstOrDefaultAsync(); ;
        }
        public IEnumerable<Models.WorkSpace> GetList()
        {
            return context.WorkSpaces.ToList();
        }
        public async Task<IEnumerable<Page>> GetListPages(int workSpaceId)
        {
            return await context.Pages.Where(x => x.WorkSpaceId == workSpaceId).ToListAsync();
        }

        public async Task<Models.WorkSpace> Create(Models.WorkSpace workSpace)
        {
            await context.WorkSpaces.AddAsync(workSpace);

            return workSpace;
        }
        public async Task<Models.WorkSpace> ChangeName(WorkSpaceDTO changeNameWorkSpaceDTO)
        {
            var findWorkSpace = await context.WorkSpaces.FindAsync(changeNameWorkSpaceDTO.Id);
            findWorkSpace.Name = changeNameWorkSpaceDTO.Name;

            return findWorkSpace;
        }
        public void Update(Models.WorkSpace workSpace)
        {
            context.Entry(workSpace).State = EntityState.Modified;
        }

        public void Delete(Models.WorkSpace workSpace)
        {
            context.WorkSpaces.Remove(workSpace);
        }
    }
}
