using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class UpdateBlockTitleDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
