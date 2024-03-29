﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryWorkSpace
    {
        public Task<IEnumerable<WorkSpace.Models.WorkSpace>> GetWorkSpaces(string userId);
        public Task<Models.WorkSpace> GetPersonalWorkSpace(string userId);
        public IEnumerable<WorkSpace.Models.WorkSpace> GetList();
        public Task<IEnumerable<Page>> GetListPages(int workSpaceId);        
        public Task<Models.WorkSpace> GetWorkSpaceById(int workSpaceId);
        public Task<Models.WorkSpace> Create(Models.WorkSpace workSpace);
        public void Update(Models.WorkSpace workSpace);
        public void Delete(Models.WorkSpace workSpace);

    }
}
