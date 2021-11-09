using Learning.AspNetCore.OData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions options)
            : base(options)
        {
            if (this.Database.EnsureCreated())
            {
                this.Database.ExecuteSqlRaw("INSERT INTO Continents (Id, Name) VALUES ({0}, {1})", 0, "-");
                this.Database.ExecuteSqlRaw("INSERT INTO Countries (Id, Name, ContinentId) VALUES ({0}, {1}, {2})", 0, "-", 0);
                this.Database.ExecuteSqlRaw("INSERT INTO Cities (Id, Name, CountryId) VALUES ({0}, {1}, {2})", 0, "-", 0);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>()
                .HasMany(a => a.Countries)
                .WithOne(a => a.Continent)
                .HasForeignKey(a => a.ContinentId);

            //modelBuilder.Entity<Country>()
            //    .HasOne(a => a.Continent)
            //    .WithMany(a => a.Countries)
            //    .HasForeignKey(a => a.ContinentId);

            modelBuilder.Entity<Country>()
                .HasMany(a => a.Cities)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);

            //modelBuilder.Entity<City>()
            //    .HasOne(a => a.Country)
            //    .WithMany(a => a.Cities)
            //    .HasForeignKey(a => a.CountryId);

        }
    }
}
