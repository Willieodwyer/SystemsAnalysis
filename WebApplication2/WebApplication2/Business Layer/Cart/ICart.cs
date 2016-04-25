using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer.Cart
{
    public abstract class ICart
    {
        public abstract double getTotal(int custID);
    }
}