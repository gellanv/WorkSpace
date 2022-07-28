using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.DTO
{
    public class ElementDTO
    {
        public int Id { get; set; }

        [Required]
        public string ContentHtml { get; set; }
        [Required]
        public int BlockId { get; set; }
    }
}
