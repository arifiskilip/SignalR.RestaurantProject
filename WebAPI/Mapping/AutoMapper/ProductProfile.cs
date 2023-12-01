using AutoMapper;
using WebAPI.Dtos.Product;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryListDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
