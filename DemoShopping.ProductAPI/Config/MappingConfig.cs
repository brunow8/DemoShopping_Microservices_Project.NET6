using AutoMapper;
using DemoShopping.ProductAPI.Entities;
using DemoShopping.ProductAPI.Entities.Value_Objects;

namespace DemoShopping.ProductAPI.Config {
    public class MappingConfig {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
                return mappingConfig;
        }
    }
}
