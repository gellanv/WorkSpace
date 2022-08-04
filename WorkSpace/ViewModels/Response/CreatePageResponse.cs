using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class CreatePageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkSpaceId { get; set; }
        public IEnumerable<BlockResponse> ListBlocks { get; set; }
        public class BlockResponse
        {
            public int Id { get; set; }
            public string Title { get; set; }

            public IEnumerable<ElementResponse> ListElements { get; set; }

            public class ElementResponse
            {
                public int Id { get; set; }
                public string ContentHtml { get; set; }
            }
        }
    }
}
