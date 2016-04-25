using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhoneRetailer.BusinessLayer.Cart
{

    //Concrete Decorator class inherits from CartDecorator
    public class WithCase : CartDecorator
    {
        public WithCase(ICart c)
            : base(c)
        {}
        public override double getTotal(int custID)
        {
            Console.WriteLine("Case decorator applied to Cart.");
            return base.getTotal(custID) * 0.97;
        }
    }
}