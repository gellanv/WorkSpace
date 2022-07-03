using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class WorkSpaceRepository : IRepositoryWorkSpace
    {
        private readonly WorkSpaceContext context;

        public WorkSpaceRepository(WorkSpaceContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<Models.WorkSpace>> GetWorkSpaces(string userId)
        {
            return await context.WorkSpaces.Where(x => x.UserId == userId).ToListAsync();
        }
        
        public IEnumerable<Models.WorkSpace> GetList()
        {
            return context.WorkSpaces.ToList();
        }
        public Models.WorkSpace Get(int id)
        {
            return context.WorkSpaces.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Create(Models.WorkSpace workSpace)
        {
            context.WorkSpaces.Add(workSpace);
        }
        public void Update(Models.WorkSpace workSpace)
        {
            context.Entry(workSpace).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Models.WorkSpace workSpace = context.WorkSpaces.Find(id);
            if (workSpace != null)
                context.WorkSpaces.Remove(workSpace);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
