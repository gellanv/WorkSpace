using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private readonly WorkSpaceContext context;

        public UserRepository(WorkSpaceContext _context)
        {
            context = _context;
        }
        public IEnumerable<User> GetList()
        {
            return context.Users.ToList();
        }
        public User Get(String id)
        {
            return context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        public void Create(User user)
        {
            context.Users.Add(user);
        }
        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
        public void Delete(String id)
        {
            User user = context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }
        

        
    }
}
