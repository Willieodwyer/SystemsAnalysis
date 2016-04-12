using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WebApplication2
{
    public class Product
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int SupplierID { get; set; }
        public string Name { get; set; }

        public Product(int productID, double price, string type, int supplierID, string name)
        {
            ProductID = productID;
            Price = price;
            Type = type;
            SupplierID = supplierID;
            Name = name;
        }

        public Product(double price,string type, int supplierID, string name)
        {
            ProductMapper.GetProductID(this);
            Price = price;
            Type = type;
            SupplierID = supplierID;
            Name = name;
        }

        public void addProduct()
        {
           ProductMapper.AddProduct(this);
        }


        public void editProduct(double price, string type, int supplierID, string name)
        {
            Price = price;
            Type = type;
            SupplierID = supplierID;
            Name = name;
            ProductMapper.editProduct(this);
        }

        public Product selectProduct(int pID)
        {
            return ProductMapper.SelectProduct(pID);
        }
    }
}
