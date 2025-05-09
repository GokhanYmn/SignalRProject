using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonailList()
        {
            var value =_mapper.Map<List<ResultTestimonialDto>>( _testimonialService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Yorum Silindi");
        }

        [HttpPost]
        public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            var value=_mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Yorum Eklendi");
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Yorum Güncellendi");
        }

    }
}
