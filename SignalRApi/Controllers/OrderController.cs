using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderservice, IMapper mapper)
        {
            _orderservice = orderservice;
            _mapper = mapper;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderservice.TTotalOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderservice.TLastOrderPrice());
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderservice.TActiveOrderCount());
        }
    }
}
