using RentalHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class Property
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string ProfileId { get; set; }
        public Profile Rentee { get; set; }
        public string RenterId { get; set; }
        public Renter Renter { get; set; }
        public PropertyType Type { get; set; }
        public int BedRooms { get; set; }
        public int Baths { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public bool Available { get; set; }
    }
}
