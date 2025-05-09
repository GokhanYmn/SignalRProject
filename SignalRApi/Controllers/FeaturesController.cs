using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.FeatureDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeaturesList()
        {
            var value = _featureService.TGetListAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult FeaturesCreate(CreateFeatureDto createFeatureDto)
        {
            var value=_mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);
            return Ok("Özellik Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult FeaturesDelete(int id)
        {
            var value= _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Özellik Silindi");

        }

        [HttpPut]
        public IActionResult FeaturesUpdate(UpdateFeatureDto updateFeatureDto)
        {
            var value=_mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);
            return Ok("Özellik Güncellendi");
        }

        [HttpGet("GetFeatures")]
        public IActionResult FeaturesGet(int id)
        {
            var value=_featureService.TGetById(id);
            return Ok(value);
        }

    }
}
