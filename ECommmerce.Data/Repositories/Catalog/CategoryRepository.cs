using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDbContext context)
             : base(context)
        { }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            return await ECommerceDbContext.Categories
                .Include(p => p.Products)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await ECommerceDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        private ECommerceDbContext ECommerceDbContext
        {
            get { return Context as ECommerceDbContext; }
        }
    }
}
