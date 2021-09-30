using ECommerce.Data;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();
            return category;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Remove(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return await _unitOfWork.CategoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task UpdateCategory(Category cateogryToBeUpdated, Category category)
        {
            cateogryToBeUpdated.Name = category.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
