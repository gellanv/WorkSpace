using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.DTO
{
    public class WorkSpaceWithListPagesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PagesDTO> Pages { get; set; }
        public class PagesDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime DateCreate { get; set; }
            public bool Favourite { get; set; }
        }
    }
}
