using ECommerce.Data.Repositories;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;

        public UnitOfWork(ECommerceDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository = _productRepository ?? new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
