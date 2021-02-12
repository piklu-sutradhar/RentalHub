using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class Profile
    {
        [Key]
        public string Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
