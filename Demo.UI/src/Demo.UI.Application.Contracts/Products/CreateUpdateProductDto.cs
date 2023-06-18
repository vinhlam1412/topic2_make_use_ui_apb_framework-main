using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.UI.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        public string? ProductID { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? Unit { get; set; }

        [Required]
        public string? SiteCode { get; set; }

        [Required]
        public int Quanity { get; set; }

        public string? QRCode { get; set; }

        [Required]
        public double SalesPrice { get; set; }

        [Required]
        public double ExtenedCost { get; set; }
    }
}
