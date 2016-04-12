using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Business_Layer
{
    public class goldOrderInvoice : Invoice
    {
        public static Invoice createInvoice()
        {
            return new goldOrderInvoice();
        }
    }
}