using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer.Cart
{
    public abstract class CartDecorator : ICart
    {
        protected ICart cBase;
        
        protected CartDecorator(ICart c)
        {
            cBase = c; 
        }
 
        public override double getTotal(int custID)
        {
            return cBase.getTotal(custID); 
        }
    }
}