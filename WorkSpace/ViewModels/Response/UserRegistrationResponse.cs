using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class UserRegistrationResponse
    {       
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
