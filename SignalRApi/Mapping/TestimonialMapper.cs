using AutoMapper;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapper:Profile
    {
        public TestimonialMapper()
        {
            CreateMap<Testimonial,CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,GetTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();
        }
    }
}
