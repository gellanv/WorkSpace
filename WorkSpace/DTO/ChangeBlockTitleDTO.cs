using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class ChangeBlockTitleDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string UserId { get; set; }
    }
}
