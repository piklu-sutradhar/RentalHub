using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class Rentee
    {
        [Key]
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public Address Address{ set; get; }
    }
}
