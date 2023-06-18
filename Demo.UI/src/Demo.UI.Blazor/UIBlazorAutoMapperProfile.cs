using AutoMapper;
using Demo.UI.OrderDetails;
using Demo.UI.Orders;
using Demo.UI.Products;

namespace Demo.UI.Blazor;

public class UIBlazorAutoMapperProfile : Profile
{
    public UIBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        CreateMap<OrderDto, CreateUpdateOrderDto>();
        CreateMap<ProductDto, CreateUpdateProductDto>();
     

    }
}
