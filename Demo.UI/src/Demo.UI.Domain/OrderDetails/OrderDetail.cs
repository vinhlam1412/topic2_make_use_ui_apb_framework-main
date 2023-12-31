﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Demo.UI.OrderDetails
{
    public class OrderDetail : Entity
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
       
        public override object[] GetKeys()
        {
            return new object[] { OrderID, ProductID };
        }
    }
}
