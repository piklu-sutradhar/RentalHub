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
        public int Id { get; set; }
        public string Title { get; set; }
        public int? RenteeId { get; set; }
        public Rentee CurrentRentee { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public PropertyType Type { get; set; }
        public int BedRooms { get; set; }
        public int Baths { get; set; }
        public int AddressId { get; set; }
        public Address PropertyAddress { get; set; }
        public bool Available { get; set; }
    }
}
