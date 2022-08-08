using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class ChangeBlockTitleResponse
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Title { get; set; }
        public string Style { get; set; }
        public IEnumerable<ChangeBlockTitleElementResponse> Elements { get; set; }
        public class ChangeBlockTitleElementResponse
        {
            public int Id { get; set; }
            public string ContentHtml { get; set; }
            public int Position { get; set; }
        }
    }
}
