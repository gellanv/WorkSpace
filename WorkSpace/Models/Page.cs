using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WorkSpace.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        [DefaultValue("false")]
        public bool PersonalPage { get; set; }
        [DefaultValue("false")]
        public bool Favourite { get; set; }
        [DefaultValue("false")]
        public bool Deleted  { get; set; }
        public int WorkSpaceId { get; set; }

        public WorkSpace WorkSpace { get; set; }
        public List<Block>Blocks { get; set; }
    }
}
