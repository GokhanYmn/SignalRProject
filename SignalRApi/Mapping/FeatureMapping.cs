using AutoMapper;
using SignalRDtoLayer.FeatureDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
        }
    }
}
