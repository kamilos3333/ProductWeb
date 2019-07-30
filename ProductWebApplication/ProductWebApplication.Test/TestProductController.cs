using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductWebApplication.Controllers;
using ProductWebApplication.Data.Models;
using ProductWebApplication.Services.ProductService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductWebApplication.Test
{
    public class TestProductController
    {
        [Fact]
        public async Task GetProduct_ReturnOk()
        {
            var service = new Mock<IProductService>();
            var apiController = new ProductController(service.Object);
            var result = await apiController.List();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProduct_ReturnAllProduct()
        {
            var service = new Mock<IProductService>();
            service.Setup(x => x.GetAllProduct()).ReturnsAsync(GetTestProduct());
            var apiController = new ProductController(service.Object);
            var result = await apiController.List();
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsAssignableFrom<IEnumerable<Product>>(objectResult.Value);
            Assert.Equal(3, product.Count());
        }

        [Fact]
        public async Task AddProduct_CreateResponse()
        {
            var testItem = new Product()
            {
                Id = new Guid("f252d3e4-41a7-4e73-a24b-3729db5111c5"),
                Name = "Produkt testowy 13",
                Price = 3.99M
            };

            var service = new Mock<IProductService>();
            service.Setup(x => x.Insert(testItem));
            var apiController = new ProductController(service.Object);
            var insertFakeData = await apiController.AddProduct(testItem);
            Assert.IsType<CreatedAtActionResult>(insertFakeData);
        }

        [Fact]
        public async Task PutProduct_OkResult()
        {
            var testItem = new Product()
            {
                Id = new Guid("4a19f0f6-0247-40b0-8fc1-f2d872c76824"),
                Name = "Test",
                Price = 119.99M
            };

            var service = new Mock<IProductService>();
            service.Setup(x => x.Edit(testItem));
            var apiController = new ProductController(service.Object);
            var editFakeData = await apiController.UpdateProduct(testItem.Id, testItem);
            Assert.IsType<OkResult>(editFakeData);
        }

        [Fact]
        public async Task GetPassIdProduct_NotFound()
        {
            var testGuid = Guid.NewGuid();
            var service = new Mock<IProductService>();
            service.Setup(x => x.GetProductId(testGuid)).ReturnsAsync(GetTestProduct().Find(x => x.Id == testGuid));
            var apiController = new ProductController(service.Object);
            var notFoundResult = await apiController.GetProductById(testGuid);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task GetPassIdProduct_OkResult()
        {
            var testGuid = new Guid("a0057ac9-d63f-4255-a574-077f528f4573");
            var service = new Mock<IProductService>();
            service.Setup(x => x.GetProductId(testGuid)).ReturnsAsync(GetTestProduct().Find(x => x.Id == testGuid));
            var apiController = new ProductController(service.Object);
            var okResult = await apiController.GetProductById(testGuid);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task DeleteProduct_OkResult()
        {
            var testGuid = new Guid("a0057ac9-d63f-4255-a574-077f528f4573");
            var service = new Mock<IProductService>();
            var apiController = new ProductController(service.Object);
            var okResult = await apiController.RemoveProduct(testGuid);
            Assert.IsType<OkResult>(okResult);
        }

        private List<Product> GetTestProduct()
        {
            var product = new List<Product>()
            {
                new Product()
                {
                    Id = new Guid("a0057ac9-d63f-4255-a574-077f528f4573"),
                    Name = "Produkt testowy 1",
                    Price = 13.99M
                },
                new Product()
                {
                    Id = new Guid("71849d91-e71b-4777-b7b5-7f721b7c7cfa"),
                    Name = "Produkt testowy 2",
                    Price = 2.45M
                },
                new Product()
                {
                    Id = new Guid("4a19f0f6-0247-40b0-8fc1-f2d872c76824"),
                    Name = "Produkt testowy 3",
                    Price = 119.99M
                }
            };
            return product;
        }
    }
}


