using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class RegisterModel
    {
        [Required]
        public string Email { set; get; }
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
