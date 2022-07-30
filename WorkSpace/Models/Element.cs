using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string ContentHtml { get; set; }
        public int BlockId { get; set; }
        public int Position { get; set; }

        public Block Block { get; set; }
    }
}
