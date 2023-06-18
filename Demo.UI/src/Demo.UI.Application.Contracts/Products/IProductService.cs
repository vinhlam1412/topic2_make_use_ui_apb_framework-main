using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo.UI.Products
{
    public interface IProductService : ICrudAppService< //Defines CRUD methods
        ProductDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto>,IApplicationService //Used to create/update a book
    {
        Task<ProductDto> GetProductByName(string name);
       // Task<ProductDto> GetAsync(Guid id);
    }
}
