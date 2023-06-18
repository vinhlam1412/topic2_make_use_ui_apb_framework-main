using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.UI.Products
{
    public interface IProductService : ICrudAppService< 
        ProductDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateProductDto>,IApplicationService 
    {
        Task<ProductDto> GetProductByName(string name);

        Task<PagedResultDto<ProductDto>> GetListProductAsync(GetListProductDto input);
    }
}
