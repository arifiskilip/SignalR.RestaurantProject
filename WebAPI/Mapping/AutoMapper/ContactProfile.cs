using AutoMapper;
using WebAPI.Dtos.Contact;
using WebAPI.Entities;

namespace WebAPI.Mapping.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactAddDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<Contact, ContactListDto>().ReverseMap();
        }
    }
}
