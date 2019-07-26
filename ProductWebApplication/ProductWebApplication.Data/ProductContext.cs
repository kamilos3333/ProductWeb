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
        }

        public DbSet<Product> Products { get; set; }
    }
}
