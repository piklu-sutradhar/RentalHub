using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class Address
    {
        [Key]
        public string Id { set; get; }
        [Required]
        public string AddressLine1 { set; get; }
        public string AddressLine2 { set; get; }
        [Required]
        public string City { set; get; }
        [Required]
        public string Province { set; get; }
        [Required]
        public string Country { set; get; }
        [Required]
        public string PostalCode { set; get; }
    }
}
