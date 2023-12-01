using AutoMapper;
using WebAPI.Dtos.Discount;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, DiscountAddDto>().ReverseMap();
            CreateMap<Discount, DiscountUpdateDto>().ReverseMap();
            CreateMap<Discount, DiscountListDto>().ReverseMap();
        }
    }
}
