using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        public int WorkSpaceId { get; set; }

        public List<Block>Blocks { get; set; }
    }
}
