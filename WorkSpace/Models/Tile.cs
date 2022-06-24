using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Tile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlockId { get; set; }

        public Block Block { get; set; }
        public List<Element> Elements { get; set; }
    }
}
