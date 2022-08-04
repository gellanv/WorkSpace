using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Request
{
    public class UpdateBlockRequest
    {
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
        
    }
}
