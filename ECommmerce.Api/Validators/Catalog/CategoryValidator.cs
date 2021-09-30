using ECommerce.Api.Models.Catalog;
using FluentValidation;

namespace ECommerce.Api.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
