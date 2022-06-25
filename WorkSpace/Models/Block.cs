using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Coordinates { get; set; }
        public int PageId { get; set; }
        

        public Page Page { get; set; }
        public List<Element> Elements { get; set; }
    }
}
