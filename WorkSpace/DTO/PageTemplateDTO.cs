using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class PageTemplateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BlockTemplateDTO> Blocks { get; set; }
        public class BlockTemplateDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Style { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public IEnumerable<ElementTemplateDTO> Elements { get; set; }

            public class ElementTemplateDTO
            {
                public int Id { get; set; }
                public string ContentHtml { get; set; }
            }
        }

    }
}
