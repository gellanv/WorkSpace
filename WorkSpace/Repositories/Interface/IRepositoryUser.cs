using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryUser
    {
        IEnumerable<User> GetList();
        //User Get(int id);
        User Get(String id);
        void Create(User user);
        void Update(User user);
        //void Delete(int id);
        void Delete(String id);

    }
}
