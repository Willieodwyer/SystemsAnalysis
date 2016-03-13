using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Stock
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Stock(int productID, int quantity)
        {
            ProductID = productID;
            Quantity = quantity;
        }
    }
}