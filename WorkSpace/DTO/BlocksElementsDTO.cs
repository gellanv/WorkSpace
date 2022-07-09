using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.DTO
{
    public class BlocksElementsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<ElementDTO> Elements { get; set; }

        public class ElementDTO
        {
            public int Id { get; set; }
            public string ContentHtml { get; set; }
        }
    }
}
