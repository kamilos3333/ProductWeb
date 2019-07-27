using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductWebApplication.Data.Models;
using ProductWebApplication.Services.ProductService.Interface;

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
        public async Task<IEnumerable<Product>> Get()
        {
            return await productService.GetAllProduct();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var item = await productService.GetProductId(id);

            if (item is null)
                return NotFound();

            return item;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product value)
        {
            await productService.Insert(value);
            return CreatedAtAction(nameof(Product), new { id = value.Id }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Product value)
        {
            if (id != value.Id)
                return BadRequest();

            await productService.Edit(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var value = await productService.GetProductId(id);
            await productService.Delete(value);
            return NoContent();
        }
    }
}
