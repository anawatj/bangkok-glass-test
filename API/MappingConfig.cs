using AutoMapper;
using Core.Domains;
using Core.Dtos;
namespace API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Region, SelectItemDto>()
                .ForMember(t => t.Value, t => t.MapFrom(t => t.Id))
                .ForMember(t=>t.Text,t=>t.MapFrom(t=>t.RegionName));

                config.CreateMap<City, SelectItemDto>()
                 .ForMember(t => t.Value, t => t.MapFrom(t => t.Id))
                 .ForMember(t => t.Text, t => t.MapFrom(t => t.CityName));

                config.CreateMap<Category, SelectItemDto>()
                .ForMember(t => t.Value, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.Text, t => t.MapFrom(t => t.CategoryName));

                config.CreateMap<Product, SelectItemDto>()
                .ForMember(t => t.Value, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.Text, t => t.MapFrom(t => t.ProductName));

                config.CreateMap<Order, OrderDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t=>t.RegionId,t=>t.MapFrom(t=>t.RegionId))
                .ForMember(t=>t.RegionName,t=>t.MapFrom(t=>t.Region.RegionName))
                .ForMember(t=>t.CityId,t=>t.MapFrom(t=>t.CityId))
                .ForMember(t=>t.CityName,t=>t.MapFrom(t=>t.City.CityName))
                .ForMember(t=>t.CategoryId,t=>t.MapFrom(t=>t.CategoryId))
                .ForMember(t=>t.CategoryName,t=>t.MapFrom(t=>t.Category.CategoryName))
                .ForMember(t=>t.ProductId,t=>t.MapFrom(t=>t.ProductId))
                .ForMember(t=>t.ProductName,t=>t.MapFrom(t=>t.Product.ProductName))
                .ForMember(t=>t.Quantity,t=>t.MapFrom(t=>t.Quantity))
                //.ForMember(t=>t.UnitPrice,t=>t.MapFrom(t=>t.UnitPrice))
                .ForMember(t=>t.TotalPrice,t=>t.MapFrom(t=>t.TotalPrice));


                config.CreateMap<OrderDto,Order>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.RegionId, t => t.MapFrom(t => t.RegionId))
                .ForMember(t => t.CityId, t => t.MapFrom(t => t.CityId))
                .ForMember(t => t.CategoryId, t => t.MapFrom(t => t.CategoryId))
                .ForMember(t => t.ProductId, t => t.MapFrom(t => t.ProductId))
                .ForMember(t => t.Quantity, t => t.MapFrom(t => t.Quantity))
                //.ForMember(t => t.UnitPrice, t => t.MapFrom(t => t.UnitPrice))
                .ForMember(t => t.TotalPrice, t => t.MapFrom(t => t.TotalPrice));


                config.CreateMap<ProductDto, Product>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.CategoryId, t => t.MapFrom(t => t.CategoryId))
                .ForMember(t => t.ProductName, t => t.MapFrom(t => t.ProductName))
                .ForMember(t => t.UnitPrice, t => t.MapFrom(t => t.UnitPrice));

                config.CreateMap<Product, ProductDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.CategoryId, t => t.MapFrom(t => t.CategoryId))
                .ForMember(t => t.CategoryName, t => t.MapFrom(t => t.Category.CategoryName))
                .ForMember(t => t.ProductName, t => t.MapFrom(t => t.ProductName))
                .ForMember(t => t.UnitPrice, t => t.MapFrom(t => t.UnitPrice));
            });
            return mappingConfig;

        }
    }
}
