using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
