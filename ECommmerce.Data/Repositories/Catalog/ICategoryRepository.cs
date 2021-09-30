using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IList<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

    }
}
