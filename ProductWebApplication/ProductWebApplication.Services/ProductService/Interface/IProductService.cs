using ProductWebApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApplication.Services.ProductService.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductId(Guid id);
        Task Insert(Product product);
        Task Delete(Product product);
        Task Edit(Product product);
    }
}
