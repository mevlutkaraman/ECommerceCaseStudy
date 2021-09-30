using ECommerce.Api.Models.Catalog;
using FluentValidation;

namespace ECommerce.Api.Validators
{
    public class ProductValidator: AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Title)
              .NotEmpty()
              .MaximumLength(200);
        }
    }
}
