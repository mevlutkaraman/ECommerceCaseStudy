using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Models.Catalog;
using ECommerce.Api.Validators;
using ECommerce.Domain;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CategoryListModel>>> GetAllMusics()
        {
            var categories = await _categoryService.GetAllCategories();
            var categoryListModel = categories.Select(c => new CategoryListModel { Name = c.Name });

            return Ok(categoryListModel);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return Ok(categoryModel);
        }
        [HttpPost("")]
        public async Task<ActionResult<CategoryModel>> CreateCategory([FromBody] CategoryModel model)
        {
            var validator = new CategoryValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var productToCreate = _mapper.Map<CategoryModel, Category>(model);
            var newCategory = await _categoryService.CreateCategory(productToCreate);
            var category = await _categoryService.GetCategoryById(newCategory.Id);
            var categoryModel = _mapper.Map<Category, CategoryModel>(category);

            return Ok(categoryModel);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateMusic(int id, [FromBody] CategoryModel model)
        {
            var validator = new CategoryValidator();
            var validationResult = await validator.ValidateAsync(model);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); 

            var categoryToBeUpdate = await _categoryService.GetCategoryById(id);
            if (categoryToBeUpdate == null)
                return NotFound();

            var category = _mapper.Map<CategoryModel, Category>(model);
            await _categoryService.UpdateCategory(categoryToBeUpdate, category);

            var updatedCategory = await _categoryService.GetCategoryById(id);
            var categoryModel = _mapper.Map<Category, CategoryModel>(updatedCategory);

            return Ok(categoryModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest();

            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound();

            await _categoryService.DeleteCategory(category);

            return NoContent();
        }
    }
}