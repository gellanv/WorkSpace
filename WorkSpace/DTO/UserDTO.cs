using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
namespace WorkSpace.DTO
{
    public class UserDTO
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Photo { get; set; }
        public string Company { get; set; }
        public List<Models.WorkSpace> WorkSpaces { get; set; }
    }
}
