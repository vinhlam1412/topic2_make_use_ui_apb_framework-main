using Demo.UI.OrderDetails;
using Demo.UI.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.UI.Orders
{
    public interface IOrderAppService :
        ICrudAppService<
            OrderDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderDto>
    {
        Task<List<ProductDto>> GetListAllProductAsync(Guid id);
       
    }
 
}
