using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Models
{
    public class ProfileViewModel : ProfileModel
    {
        public string Id { get; set; }
    }
}
