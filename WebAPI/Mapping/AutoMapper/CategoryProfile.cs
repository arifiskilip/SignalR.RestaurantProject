using AutoMapper;
using WebAPI.Dtos.Category;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
