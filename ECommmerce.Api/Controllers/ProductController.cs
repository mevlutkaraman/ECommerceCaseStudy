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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<ProductListModel>>> GetAllProducts(ProductSearchModel model)
        {
            var products = await _productService.GetAllProducts(model.Keywords, model.MinimumStockQuantity, model.MaximumStockQuantity);

            var productListModel = products.Select(p => new ProductListModel
            {
                Title = p.Title,
                Description = p.Description,
                StockQuantit = p.StockQuantity,
                CategoryModel = new CategoryModel { Id = p.CategoryId, Name = p.Category.Name }
            });

            return Ok(productListModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            var productModel = _mapper.Map<Product, ProductModel>(product);

            return Ok(productModel);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel model)
        {
            var validator = new ProductValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var productToCreate = _mapper.Map<ProductModel, Product>(model);
            var newProduct = await _productService.CreateProduct(productToCreate);
            var product = await _productService.GetProductById(newProduct.Id);
            var productModel = _mapper.Map<Product, ProductModel>(product);

            return Ok(productModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct(int id, [FromBody] ProductModel model)
        {
            var validator = new ProductValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var productToBeUpdated = await _productService.GetProductById(id);
            if (productToBeUpdated == null)
                return NotFound();

            var product = _mapper.Map<ProductModel, Product>(model);
            await _productService.UpdateProduct(productToBeUpdated, product);
            var updatedProduct = await _productService.GetProductById(id);
            var productModel = _mapper.Map<Product, ProductModel>(updatedProduct);

            return Ok(productModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);

            await _productService.DeleteProduct(product);

            return NoContent();
        }
    }
}