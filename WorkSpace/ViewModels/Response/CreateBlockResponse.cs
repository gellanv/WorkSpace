﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class CreateBlockResponse
    {
        public int Id { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
        public string Title { get; set; } = "Untitled";
        public string Style { get; set; } = "NoStyle";
        public int PageId { get; set; }
    }
}
