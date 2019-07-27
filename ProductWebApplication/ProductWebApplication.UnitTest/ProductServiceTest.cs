using Microsoft.EntityFrameworkCore;
using ProductWebApplication.Data;
using ProductWebApplication.Data.Models;
using ProductWebApplication.Services.ProductService;
using ProductWebApplication.Services.ProductService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductWebApplication.UnitTest
{
    public class ProductServiceTest
    {
        //[Fact]
        //public async Task AddProduct()
        //{
        //    IProductService service = GetMemoryProductService();
        //    Product product = new Product()
        //    {
        //        Id = new Guid(),
        //        Name = "Test12341",
        //        Price = 2.33M
        //    };
        //    Product saveProduct = service.Insert(product);
        //    Assert.Equal()
        //}

        //private IProductService GetMemoryProductService()
        //{
        //    DbContextOptions<ProductContext> options;
        //    var builder = new DbContextOptionsBuilder<ProductContext>();
        //    options = builder.Options;
        //    ProductContext productContext = new ProductContext(options);
        //    productContext.Database.EnsureDeleted();
        //    productContext.Database.EnsureCreated();
        //    return new ProductService(productContext);
        //}
    }
}
