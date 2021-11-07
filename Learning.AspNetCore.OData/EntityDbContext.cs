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
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>()
                .HasMany(a => a.Countries)
                .WithOne(a => a.Continent)
                .HasForeignKey(a => a.ContinentId);

            modelBuilder.Entity<Country>()
                .HasMany(a => a.Cities)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);
        }
    }
}
