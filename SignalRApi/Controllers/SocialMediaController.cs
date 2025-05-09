using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _socialMediaService.TGetListAll();
            return Ok(value);
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value=_socialMediaService.TGetById(id);
            return Ok(value);

        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Media Silindi");
        }

        [HttpPost]
        public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
        {
            var value=_mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Sosyal Media Eklendi");
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value=_mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Media Güncellendi");

        }
    }
}
