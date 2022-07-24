using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Request
{
    public class CreatePageRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int WorkSpaceID { get; set; }
    }
}
