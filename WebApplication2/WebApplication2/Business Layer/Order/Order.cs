using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Text;

namespace WebApplication2
{
    public abstract class Order
    {
        public abstract int OrderID { get; set; }
        public abstract int CustomerID { get; set; }
        public abstract Product Product { get; set; }
        public abstract int SupplierID { get; set; }
        public abstract String Address { get; set; }
        public abstract double Amount { get; set; }
        public abstract DateTime Date { get; set; }

        public abstract string CreateOrder();
        public abstract string EditOrder(int orderID, int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date);
        public abstract string AddProduct(int pID, double amnt);
        public abstract string RemoveProduct(int pID);
        public abstract string PrintOrder();
    }
}