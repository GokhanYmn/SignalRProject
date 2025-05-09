using AutoMapper;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
        }
    }
}
