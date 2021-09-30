using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IList<Product>> GetAllProductsAsync(string keywords, int minimumStockQuantity, int maximumStockQuantity);

        Task<Product> GetProductById(int id);
    }
}
