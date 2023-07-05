using Core.Domains;
using Implements.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Region> Regions { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            string regionIdEast = Guid.NewGuid().ToString();
            string regionIdWest = Guid.NewGuid().ToString();

            modelBuilder.Entity<Region>().HasData(
                new Region() { Id = regionIdEast, RegionName = "EAST" },
                new Region() { Id = regionIdWest, RegionName = "WEST" });

            modelBuilder.Entity<City>().HasData(
                 new City() { Id = Guid.NewGuid().ToString(), RegionId = regionIdEast, CityName = "Boston" },
                 new City() { Id = Guid.NewGuid().ToString(), RegionId = regionIdEast, CityName = "New York" },
                 new City() { Id = Guid.NewGuid().ToString(), RegionId = regionIdWest, CityName = "Los Angeles" },
                 new City() { Id = Guid.NewGuid().ToString(), RegionId = regionIdWest, CityName = "Santiago" }
                );


            string cookieId = Guid.NewGuid().ToString();
            string crackerId = Guid.NewGuid().ToString();
            string barsId = Guid.NewGuid().ToString();
            string snackId = Guid.NewGuid().ToString();
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = cookieId, CategoryName = "Cookies" },
                new Category() { Id = crackerId, CategoryName = "Crackers" },
                new Category() { Id = barsId, CategoryName = "Bars" },
                new Category() { Id = snackId, CategoryName = "Snack" }
             );


            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = cookieId, ProductName = "Arrowroot" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = cookieId, ProductName = "Chocolate Chip" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = crackerId, ProductName = "Whole Wheat" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = snackId, ProductName = "Potato Chips" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = snackId, ProductName = "Pretzels" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = barsId, ProductName = "Carrot" },
                new Product() { Id = Guid.NewGuid().ToString(), CategoryId = barsId, ProductName = "Bran" }
                );
        }
    }
}
