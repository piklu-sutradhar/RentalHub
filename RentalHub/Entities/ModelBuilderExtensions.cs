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
                    Id = 1,
                    AddressLine1 = "William",
                    AddressLine2 = "Shakespeare",
                    City = "Test City",
                    Province = "Test Pro",
                    Country = "Test country",
                    PostalCode = "Test code"
                },
                new Address
                {
                    Id = 2,
                    AddressLine1 = "William",
                    AddressLine2 = "Shakespeare",
                    City = "Test City",
                    Province = "Test Pro",
                    Country = "Test country",
                    PostalCode = "Test code"
                }
            };

            List<Rentee> rentees = new List<Rentee>()
            {
                new Rentee { Id = 1, FirstName = "piklu", LastName = "Hamlet", AddressId = 1, Email = "p@test.com"},
                new Rentee { Id = 2, FirstName = "Rubel", LastName = "Hamlet",  AddressId = 2, Email = "p@test.com" },
                new Rentee { Id = 3, FirstName = "Mou", LastName = "Hamlet",  AddressId = 1, Email = "p@test.com" }
            };

            List<Property> properties = new List<Property>()
            {
                new Property{Id = 1, Title = "Rancho Property", Available = false, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1, AddressId = 1, RenteeId = 1, RenterId = 1},
                new Property{Id = 2, Title = "Succex Property", Available = false, Type = Models.PropertyType.Condo, BedRooms = 3, Baths = 2, AddressId = 2, RenteeId = 2, RenterId = 1},
                new Property{Id = 3, Title = "Globe Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 1, Baths = 1, AddressId = 1, RenterId = 1 },
                new Property{Id = 4, Title = "Private Property", Available = true, Type = Models.PropertyType.House, BedRooms = 5, Baths = 3, AddressId = 1, RenterId = 1 },
                new Property{Id = 5, Title = "Public Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1, AddressId = 1, RenterId = 1 },
                new Property{Id = 6, Title = "Rancho Property", Available = true, Type = Models.PropertyType.Townhouse, BedRooms = 4, Baths = 2, AddressId = 1, RenterId = 1},
                new Property{Id = 7, Title = "Rancho Property", Available = true, Type = Models.PropertyType.Apertment, BedRooms = 2, Baths = 1, AddressId = 1, RenterId = 1}
            };

            modelBuilder.Entity<User>().HasData(
                new User { Id="1", Email = "Piklu@yahoo.com",UserName="test"}
            );

            modelBuilder.Entity<Address>().HasData(
                addresses
            );

            modelBuilder.Entity<Rentee>().HasData(
                rentees
            );
            modelBuilder.Entity<Property>().HasData(
                properties
            );

            modelBuilder.Entity<Renter>().HasData(
                new Renter { Id = 1, FirstName = "Adam", LastName= "John", AddressId = 1}
            );
        }
    }
}
