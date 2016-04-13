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

        public Product(int productID, double price, string type, int supplierID)
        {
            ProductID = productID;
            Price = price;
            Type = type;
            SupplierID = supplierID;
        }

        public Product(double price,string type, int supplierID)
        {
            ProductID = 0;
            ProductMapper.GetProductID(this);
            Price = price;
            Type = type;
            SupplierID = supplierID;
        }

        public string addProduct()
        {
           return ProductMapper.AddProduct(this);
        }


        public string editProduct(double price, string type, int supplierID)
        {
            Price = price;
            Type = type;
            SupplierID = supplierID;
            return ProductMapper.editProduct(this);
        }

        public string DeleteProduct()
        {
            return ProductMapper.DeleteProduct(this);
        }

        public Product selectProduct(int pID)
        {
            return ProductMapper.SelectProduct(pID);
        }

        public static double getProductPrice(int pID)
        {
            return ProductMapper.getProductPrice(pID);
        }
    }
}
