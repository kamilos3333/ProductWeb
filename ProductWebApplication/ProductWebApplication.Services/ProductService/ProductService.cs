using Microsoft.EntityFrameworkCore;
using ProductWebApplication.Data;
using ProductWebApplication.Data.Models;
using ProductWebApplication.Services.ProductService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApplication.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ProductContext db;

        public ProductService(ProductContext db)
        {
            this.db = db;
        }

        public async Task Delete(Product product)
        {
            db.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllProduct()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductId(Guid id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task Insert(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }
    }
}
