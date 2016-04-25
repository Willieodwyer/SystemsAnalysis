using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    
    //Concrete Decorator class inherits from CartDecorator
    public class WithAccessory : CartDecorator
    {
        private ICart cartWithCase;

        public WithAccessory(ICart c)
            : base(c)
        {

        }

        public override double getTotal(int custID)
        {
            Console.WriteLine("With Accessory decorator invoked.");
            return base.getTotal(custID) * 0.98;
        }
    } 
}