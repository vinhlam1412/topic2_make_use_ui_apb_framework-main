using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.UI.Orders
{
    public enum OrderStatus
    {
        Ordered,
        Hold,
        PrintedInvoice,
        Processing,
        ShipOnly,
        DeliveryAllocation,
        Completed,
        Cancel
    }
}
