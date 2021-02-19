using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHub.Entities
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Address> addresses = new List<Address>()
            {
                new Address
                {
                    Id = Guid.NewGuid().ToString(),
                    AddressLine1 = "William",
                    AddressLine2 = "Shakespeare",
                    City = "Test City",
                    Province = "Test Pro",
                    Country = "Test country",
                    PostalCode = "Test code"
                },
                new Address
                {
                    Id = Guid.NewGuid().ToString(),
                    AddressLine1 = "William",
                    AddressLine2 = "Shakespeare",
                    City = "Test City",
                    Province = "Test Pro",
                    Country = "Test country",
                    PostalCode = "Test code"
                }
            };

           /* List<Rentee> rentees = new List<Rentee>()
            {
                new Rentee { Id = 1, FirstName = "piklu", LastName = "Hamlet", AddressId = 1, Email = "p@test.com"},
                new Rentee { Id = 2, FirstName = "Rubel", LastName = "Hamlet",  AddressId = 2, Email = "p@test.com" },
                new Rentee { Id = 3, FirstName = "Mou", LastName = "Hamlet",  AddressId = 1, Email = "p@test.com" }
            };*/

            List<Property> properties = new List<Property>()
            {
                new Property{Id = Guid.NewGuid().ToString(), Title = "Rancho Property", Available = false, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1},
                new Property{Id = Guid.NewGuid().ToString(), Title = "Succex Property", Available = false, Type = Models.PropertyType.Condo, BedRooms = 3, Baths = 2 },
                new Property{Id = Guid.NewGuid().ToString(), Title = "Globe Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 1, Baths = 1 },
                new Property{Id = Guid.NewGuid().ToString(), Title = "Private Property", Available = true, Type = Models.PropertyType.House, BedRooms = 5, Baths = 3 },
                new Property{Id = Guid.NewGuid().ToString(), Title = "Public Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1 },
                new Property{Id = Guid.NewGuid().ToString(), Title = "Rancho Property", Available = true, Type = Models.PropertyType.Townhouse, BedRooms = 4, Baths = 2 },
                new Property{Id = Guid.NewGuid().ToString(), Title = "Rancho Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1 }
            };

            modelBuilder.Entity<Address>().HasData(
                addresses
            );

            modelBuilder.Entity<Property>().HasData(
                properties
            );
        }
    }
}
