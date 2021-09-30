using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context)
            : base(context)
        { }

        public async Task<IList<Product>> GetAllProductsAsync(string keywords, int minimumStockQuantity, int maximumStockQuantity)
        {
            var query = ECommerceDbContext.Products.Include(p => p.Category).AsTracking();

            if (!string.IsNullOrEmpty(keywords))
                query = query.Where(p => p.Title.Contains(keywords) || p.Description.Contains(keywords)
                                                                    || p.Category.Name.Contains(keywords));

            if (minimumStockQuantity > 0)
                query = query.Where(p => p.StockQuantity > minimumStockQuantity);

            if (maximumStockQuantity > 0)
                query = query.Where(p => p.StockQuantity < maximumStockQuantity);

            return await query.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ECommerceDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        private ECommerceDbContext ECommerceDbContext
        {
            get { return Context as ECommerceDbContext; }
        }
    }
}
