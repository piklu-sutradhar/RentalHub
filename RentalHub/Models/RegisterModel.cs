﻿using RentalHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public UserTypes UserType { set; get; }
    }
}
