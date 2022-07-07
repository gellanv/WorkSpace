using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private WorkSpaceContext context;
        private IRepositoryBlock repositoryBlock;
        private IRepositoryElement repositoryElement;
        private IRepositoryPage repositoryPage;
        private IRepositoryWorkSpace repositoryWorkSpace;
        private IRepositoryUser repositoryUser;

        public UnitOfWork(WorkSpaceContext _context)
        {
            this.context = _context;
        }

        public IRepositoryBlock RepositoryBlock
        {
            get
            {
                return repositoryBlock = repositoryBlock ?? new BlockRepository(context);
            }
        }


        public IRepositoryElement RepositoryElement
        {
            get
            {
                return repositoryElement = repositoryElement ?? new ElementRepository(context);
            }
        }

        public IRepositoryPage RepositoryPage
        {
            get
            {
                return repositoryPage = repositoryPage ?? new PageRepository(context);
            }
        }

        public IRepositoryWorkSpace RepositoryWorkSpace
        {
            get
            {
                return repositoryWorkSpace = repositoryWorkSpace ?? new WorkSpaceRepository(context);
            }
        }

        public IRepositoryUser RepositoryUser
        {
            get
            {
                return repositoryUser = repositoryUser ?? new UserRepository(context);
            }
        }


        public Task SaveAsync()
        {
          return  context.SaveChangesAsync();
        }
    }
}
