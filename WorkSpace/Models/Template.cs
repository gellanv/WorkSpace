using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BlockTemplate> BlockTemplates { get; set; }
    }
    public class BlockTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Style { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int TemplateId { get; set; }
    }
}
