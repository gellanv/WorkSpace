using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class BlockDTO
    {
        public int PageId { get; set; }
        
        public int X { get; set; }
        
        public int Y { get; set; }
        
        public int Height { get; set; }
        
        public int Width { get; set; }
        public string Title { get; set; } = "Untitled";
        public string Style { get; set; } = "NoStyle";
    }
}
