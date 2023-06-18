using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.UI.Products
{
    public class Product: AuditedAggregateRoot<Guid>
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
