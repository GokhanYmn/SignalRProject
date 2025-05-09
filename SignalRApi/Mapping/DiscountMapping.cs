using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount,CreateDiscountDto>().ReverseMap();
            CreateMap<Discount,ResultDiscountDto>().ReverseMap();
            CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount,GetDiscountDto>().ReverseMap();
        }
    }
}
