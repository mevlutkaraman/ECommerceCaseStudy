using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProducts(string keywords, int minimumStockQuantity, int maximumStockQuantity);

        Task<Product> GetProductById(int id);

        Task<Product> CreateProduct(Product newArtist);

        Task UpdateProduct(Product productToBeUpdated, Product product);

        Task DeleteProduct(Product artist);
    }
}
