using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class AddListBlocksTemplateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BlockTemplateResponse> Blocks { get; set; }
        public class BlockTemplateResponse
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Style { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public IEnumerable<ElementTemplateResponse> Elements { get; set; }

            public class ElementTemplateResponse
            {
                public int Id { get; set; }
                public string ContentHtml { get; set; }
            }
        }

    }
}
