using AutoMapper;
using WebAPI.Dtos.About;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutAddDto>().ReverseMap();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
            CreateMap<About, AboutListDto>().ReverseMap();
        }
    }
}
