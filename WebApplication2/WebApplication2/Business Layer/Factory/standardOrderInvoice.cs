﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Business_Layer.Factory
{
    public class standardOrderInvoice : Invoice
    {
        public static Invoice createInvoice()
        {
            return new standardOrderInvoice(); 
        }
    }
}