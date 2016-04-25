using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhoneRetailer.BusinessLayer.Order
{
    public abstract class OrderDiscount
    {
        public abstract double disc { get; set; }
        public abstract void applyDiscount(Order ord);
    }
}