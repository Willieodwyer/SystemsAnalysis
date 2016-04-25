using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Business_Layer
{
    public class InvoiceFactory
    {
        public static iInvoice getInvoice(int oID, string category)
        {
            if (category == "Gold")
                return new goldOrderInvoice(oID);
            else if (category == "Silver")
                return new silverOrderInvoice(oID);
            else
                return new standardOrderInvoice(oID);
        }
    }
}
