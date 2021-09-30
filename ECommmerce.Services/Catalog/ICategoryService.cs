using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategories();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(Category newMusic);

        Task UpdateCategory(Category categoryToBeUpdated, Category category);

        Task DeleteCategory(Category category);
    }
}
