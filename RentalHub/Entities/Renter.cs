using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public class Renter
    {
        [Key]
        public string Id { get; set; }
        public string ProfileID { get; set; }
        public Profile Profile { get; set; }
        public List<Property> Properties { get; set; }
    }
}
