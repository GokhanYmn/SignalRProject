using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value=_discountService.TGetListAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
        {
            var discount=_mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discount);
            return Ok("Kampanya Eklendi.");
        }

        [HttpDelete]
        public IActionResult DiscountDelete(int id)
        {
            var value=_discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Kampanya Silindi.");
        }

        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
        {
            var value=_mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Kampanya Güncellendi");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            return Ok(values);
        }
    }
}
