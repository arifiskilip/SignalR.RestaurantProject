using AutoMapper;
using WebAPI.Dtos.Testimonial;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, TestimonialAddDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialListDto>().ReverseMap();
        }
    }
}
