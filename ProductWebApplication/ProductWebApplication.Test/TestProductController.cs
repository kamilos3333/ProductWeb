using Moq;
using ProductWebApplication.Controllers;
using ProductWebApplication.Services.ProductService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductWebApplication.Test
{
    public class TestProductController
    {
        [Fact]
        public void GetAllProduct()
        {
            var service = new Mock<IProductService>();
            var apiController = new ProductController(service.Object);
            var result = apiController.Get();
            service.Verify(x => x.GetAllProduct());
        }
    }
}
