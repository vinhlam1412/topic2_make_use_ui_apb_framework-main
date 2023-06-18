using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demo.UI.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
        public string? SiteCode { get; set; }
        public int Quanity { get; set; }
        public string? QRCode { get; set; }
        public double SalesPrice { get; set; }
        public double ExtenedCost { get; set; }
    }
}
