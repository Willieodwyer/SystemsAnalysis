using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class OrderContext
    {
        public Order Order { get; set; }

        public Order Order1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public OrderContext(int custType, int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date)
        {
            switch (custType)
            {
                case 1: Order = new StandardOrder(customerID, productID, supplierID, address, amount, date); break;
                case 2: Order = new SilverOrder(customerID, productID, supplierID, address, amount, date); break;
                case 3: Order = new GoldOrder(customerID, productID, supplierID, address, amount, date); break;                
                default: Order = new StandardOrder(customerID, productID, supplierID, address, amount, date); break;
            }
        }
    }
}