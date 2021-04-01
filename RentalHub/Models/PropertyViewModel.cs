using RentalHub.Entities;
using RentalHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Models
{
    public class PropertyViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ProfileId { get; set; }
        public PropertyType Type { get; set; }
        public int BedRooms { get; set; }
        public int Baths { get; set; }
        public string AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool Available { get; set; }
    }
}
