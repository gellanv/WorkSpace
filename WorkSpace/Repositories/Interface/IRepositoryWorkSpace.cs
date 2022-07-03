using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryWorkSpace
    {
        public Task<IEnumerable<WorkSpace.Models.WorkSpace>> GetWorkSpaces(string userId);
        IEnumerable<WorkSpace.Models.WorkSpace> GetList();
        WorkSpace.Models.WorkSpace Get(int id);
        void Create(WorkSpace.Models.WorkSpace workSpace);
        void Update(WorkSpace.Models.WorkSpace workSpace);
        void Delete(int id);
        void Save();
    }
}
