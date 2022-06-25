using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Request
{
    public class UserRequestLogIn
    {
        public int id { get; set; }//для тестирования, далее нужно удалить строку
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
