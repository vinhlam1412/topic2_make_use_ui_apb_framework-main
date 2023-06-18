using AutoMapper;
using Demo.UI.OrderDetails;
using Demo.UI.Orders;
using Demo.UI.Products;

namespace Demo.UI;

public class UIApplicationAutoMapperProfile : Profile
{
    public UIApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Order, OrderDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<CreateUpdateOrderDto, Order>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
