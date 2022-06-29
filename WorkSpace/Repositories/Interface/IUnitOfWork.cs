using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IRepositoryBlock RepositoryBlock { get; }
        IRepositoryElement RepositoryElement { get; }
        IRepositoryPage RepositoryPage { get; }
        IRepositoryWorkSpace RepositoryWorkSpace { get; }
        IRepositoryUser RepositoryUser { get; }
        void Save();
    }
}
