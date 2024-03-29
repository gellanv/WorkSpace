﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class User : IdentityUser
    {      
        public string Photo { get; set; }     
        public string Company { get; set; }
        
        public List<WorkSpace> WorkSpaces { get; set; }
    }
}
