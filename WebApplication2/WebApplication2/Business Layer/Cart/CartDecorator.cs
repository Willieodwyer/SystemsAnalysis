using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public abstract class CartDecorator : ICart
    {
        protected ICart cBase;
        
        protected CartDecorator(ICart c)
        {
            cBase = c; 
        }
 
        public override double getTotal()
        {
            return cBase.getTotal(); 
        }
    }
}