using AutoMapper;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactBooking:Profile
    {
        public ContactBooking()
        {
                CreateMap<Contact,CreateContactDto>().ReverseMap();
                CreateMap<Contact,UpdateContactDto>().ReverseMap();
                CreateMap<Contact,ResultContactDto>().ReverseMap();
                CreateMap<Contact,GetContactDto>().ReverseMap();
        }
    }
}
