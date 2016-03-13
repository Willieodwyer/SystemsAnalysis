using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public String Address { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Order(int orderID, int customerID, int productID, int supplierID, String address, double amount,
            DateTime date)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount;
            Date = date;
        }
    }
}