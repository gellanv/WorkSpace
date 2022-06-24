using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class BackCall
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        
         public User User { get; set; }
    }
}
