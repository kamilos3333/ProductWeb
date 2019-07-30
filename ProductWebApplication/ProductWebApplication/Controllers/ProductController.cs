using Microsoft.AspNetCore.Mvc;
using ProductWebApplication.Data.Models;
using ProductWebApplication.Services.ProductService.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var product = await productService.GetAllProduct();
            return Ok(product);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await productService.GetProductId(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await productService.Insert(product);
            return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await productService.Edit(product);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await productService.Delete(id);
            return Ok();
        }
    }
}
