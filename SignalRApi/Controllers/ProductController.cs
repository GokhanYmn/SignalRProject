using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _productService.TGetListAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value=_productService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi.");
        }

        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
        {
            var value=_mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Ürün Güncellendi");
        }

        [HttpPost]
        public IActionResult ProductCreate(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                Status = createProductDto.Status,
                CategoryId = createProductDto.CategoryId,
            });

            //var value=_mapper.Map<Product>(createProductDto);
            //_productService.TAdd(value);
            return Ok("Ürün Eklenmiştir");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values=_productService.TGetProductsWithCategories();
            return Ok(values);
        }

    }
}
