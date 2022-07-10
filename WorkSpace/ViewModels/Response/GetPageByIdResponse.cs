using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WorkSpace.DTO.PageDTO;

namespace WorkSpace.ViewModels.Response
{
    public class GetPageByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BlockDTO> ListBlocks { get; set; }
        //public class BlockDTO
        //{
        //    public int Id { get; set; }
        //    public string Title { get; set; }
        //    public IEnumerable<ElementDTO> ListElements { get; set; }

        //    public class ElementDTO
        //    {
        //        public int Id { get; set; }
        //        public string ContentHtml { get; set; }
        //    }
        //}
    }
}
