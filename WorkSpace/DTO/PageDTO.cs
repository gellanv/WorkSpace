using System;
using System.Collections.Generic;

namespace WorkSpace.DTO
{
    public class PageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Favourite { get; set; }
        public bool Deleted { get; set; }
        public int WorkSpaceId { get; set; }
        public IEnumerable<BlockDTO> ListBlocks { get; set; }
        public class BlockDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Style { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public IEnumerable<ElementDTO> ListElements { get; set; }

            public class ElementDTO
            {
                public int Id { get; set; }
                public string ContentHtml { get; set; }
                public int Position { get; set; }
            }
        }        
    }

    //public class BlocksElementsDTO
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public IEnumerable<ElementDTO> Elements { get; set; }

    //    public class ElementDTO
    //    {
    //        public int Id { get; set; }
    //        public string ContentHtml { get; set; }
    //    }
    //}
}
