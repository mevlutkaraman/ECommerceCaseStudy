using AutoMapper;
using ECommerce.Api.Models.Catalog;
using ECommerce.Domain;

namespace ECommerce.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Category, CategoryModel>();
            CreateMap<Product, ProductModel>();

            // Resource to Domain
            CreateMap<CategoryModel, Category>();
            CreateMap<ProductModel, Product>();
        }
    }
}
