using AutoMapper;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapper:Profile
    {
        public SocialMediaMapper()
        {
            CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap();
        }
    }
}
