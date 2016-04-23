using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public abstract class OrderDiscount
    {
        public abstract double disc { get; set; }
        public abstract void applyDiscount(Order ord);
    }
}