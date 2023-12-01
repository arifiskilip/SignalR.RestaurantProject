using AutoMapper;
using WebAPI.Dtos.Booking;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingAddDto>().ReverseMap();
            CreateMap<Booking, BookingUpdateDto>().ReverseMap();
            CreateMap<Booking, BookingListDto>().ReverseMap();
        }
    }
}
