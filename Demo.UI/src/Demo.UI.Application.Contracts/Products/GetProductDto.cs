using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demo.UI.Products
{
    public class GetListProductDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
