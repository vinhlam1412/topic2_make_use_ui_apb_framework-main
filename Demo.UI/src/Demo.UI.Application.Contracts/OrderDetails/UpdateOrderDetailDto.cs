using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.UI.OrderDetails
{
    public class UpdateOrderDetailDto
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
