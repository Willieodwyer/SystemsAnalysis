using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public abstract class ICart
    {
        public abstract double getTotal(int custID);
    }
}