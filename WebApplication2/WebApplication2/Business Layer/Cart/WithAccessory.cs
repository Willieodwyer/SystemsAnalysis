using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer.Cart
{
    
    //Concrete Decorator class inherits from CartDecorator
    public class WithAccessory : CartDecorator
    {
        

        public WithAccessory(ICart c)
            : base(c)
        {}

        public override double getTotal(int custID)
        {
            Console.WriteLine("Accessory decorator applied to Cart.");
            return base.getTotal(custID) * 0.98;
        }
    } 
}