using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string ContentHtml { get; set; }
        public int TileId { get; set; }

        public Tile Tile { get; set; }
    }
}
