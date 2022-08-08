using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class UpdateBlockResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Style { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public IEnumerable<UpdateBlockElementResponse> Elements { get; set; }
        public class UpdateBlockElementResponse
        {
            public int Id { get; set; }
            public string ContentHtml { get; set; }
            public int Position { get; set; }
        }
    }
}
