using Microsoft.EntityFrameworkCore;
using ProductWebApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductWebApplication.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(b => b.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(b => b.Name).HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = new Guid("b1fc43ab-c2a9-4e98-8ff0-0953740e1bee"),
                    Name = "Zszywacz biurowy",
                    Price = 35.15M
                },
                new Product
                {
                    Id = new Guid("bd33dd6d-2ec6-4824-b8f3-3f1395ba51df"),
                    Name = "Gumka do mazania",
                    Price = 3.06M
                }
            );
        }
        
        public DbSet<Product> Products { get; set; }
    }
}
