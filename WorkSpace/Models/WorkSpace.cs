using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class WorkSpace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<Page> Pages { get; set; }
    }
}
