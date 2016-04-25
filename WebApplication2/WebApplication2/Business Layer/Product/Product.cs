using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer
{
    public abstract class Product
    {
        public abstract int ProductID { get; set; }
        public abstract double Price { get; set; }
        public abstract string Type { get; set; }
        public abstract int SupplierID { get; set; }

        public abstract string addProduct();
        public abstract string editProduct(double price, string type, int supplierID);
        public abstract string DeleteProduct();
        public abstract Product selectProduct(int pID);






    }
}