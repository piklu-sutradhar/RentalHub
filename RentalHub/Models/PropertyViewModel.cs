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
        public string Title { get; set; }
        public string ProfileId { get; set; }
        public PropertyType Type { get; set; }
        public int BedRooms { get; set; }
        public int Baths { get; set; }
        public string AddressId { get; set; }
        public Address PropertyAddress { get; set; }
        public bool Available { get; set; }
    }
}
