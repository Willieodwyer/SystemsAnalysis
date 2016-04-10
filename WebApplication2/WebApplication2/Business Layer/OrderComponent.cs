using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public abstract class OrderComponent
    {
        public abstract int OrderID { get; set; }
        public abstract int CustomerID { get; set; }
        public abstract int ProductID { get; set; }
        public abstract int SupplierID { get; set; }
        public abstract String Address { get; set; }
        public abstract double Amount { get; set; }
        public abstract DateTime Date { get; set; }

        public abstract string CreateOrder();
        public abstract string EditOrder(int orderID, int customerID, int productID, int supplierID, String address, double amount,
            DateTime date);
        public abstract string AddProduct(int pID, double amnt);
        public abstract string RemoveProduct(int pID);
        public abstract string PrintOrder();
    }
}