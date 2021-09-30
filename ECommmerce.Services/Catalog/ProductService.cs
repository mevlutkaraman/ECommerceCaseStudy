using ECommerce.Data;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _unitOfWork.ProductRepository.AddAsync(product);
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.ProductRepository.Remove(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IList<Product>> GetAllProducts(string keywords, int minimumStockQuantity, int maximumStockQuantity)
        {
            return await _unitOfWork.ProductRepository.GetAllProductsAsync(keywords, minimumStockQuantity, maximumStockQuantity);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.Title = product.Title;
            productToBeUpdated.Description = product.Description;
            productToBeUpdated.CategoryId = product.CategoryId;
            productToBeUpdated.StockQuantity = product.StockQuantity;

            await _unitOfWork.CommitAsync();
        }
    }

}
