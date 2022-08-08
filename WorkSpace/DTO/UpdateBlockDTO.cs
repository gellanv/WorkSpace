using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class UpdateBlockDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Title { get; set; }
        public string Style { get; set; }
        public string UserId { get; set; }
        public IEnumerable<UpdateBlockElementDTO> Elements { get; set; }
        public class UpdateBlockElementDTO
        {
            public int Id { get; set; }
            public string ContentHtml { get; set; }
            public int Position { get; set; }
        }
    }
}
