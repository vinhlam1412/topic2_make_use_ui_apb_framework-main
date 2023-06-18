using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HQSoft.Sales.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
