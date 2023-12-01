using AutoMapper;
using WebAPI.Dtos.SocialMedia;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, SocialMediaAddDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
        }
    }
}
