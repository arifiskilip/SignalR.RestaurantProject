using AutoMapper;
using WebAPI.Dtos.Discount;
using WebAPI.Dtos.Feature;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureAddDto>().ReverseMap();
            CreateMap<Feature, FeatureUpdateDto>().ReverseMap();
            CreateMap<Feature, FeatureListDto>().ReverseMap();
        }
    }
}
