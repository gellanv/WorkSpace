using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    //public class BlocksElementsResponse
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public IEnumerable<DTO.BlocksElementsDTO.ElementDTO> Elements { get; set; }

    //}
    public class BlocksElementsResponse
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
