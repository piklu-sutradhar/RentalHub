using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RentalHub.Entities
{
    public class RentalHubContext : IdentityDbContext<User>
    {
        public RentalHubContext()
        {

        }
        public RentalHubContext(DbContextOptions<RentalHubContext> options)
            : base(options)
        {
        }
        //entities
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Rentee> Rentees { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    string rentalHubConnectionString = "Server=(LocalDb)\\localDB;Data Source=(LocalDb)\\localDB;Initial Catalog=RentalHub;Integrated Security=SSPI;"; // Environment.GetEnvironmentVariable("RentalHubConnectionString");
                    if (rentalHubConnectionString is null)
                        throw new Exception("Database connection string is not found, add the connection string in the Environment");
                    optionsBuilder.UseSqlServer(rentalHubConnectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.UserName);
            modelBuilder.Seed();
        }

        
    }
}
