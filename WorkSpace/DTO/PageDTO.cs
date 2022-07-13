﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.DTO
{
    public class PageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkSpaceId { get; set; }
        public IEnumerable<BlockDTO> ListBlocks { get; set; }
        public class BlockDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public IEnumerable<ElementDTO> ListElements { get; set; }

            public class ElementDTO
            {
                public int Id { get; set; }
                public string ContentHtml { get; set; }
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
