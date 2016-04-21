using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WebApplication2
{
    public class StandardProduct : Product
    {
        override public int ProductID { get; set; }
        override public double Price { get; set; }
        override public string Type { get; set; }
        override public int SupplierID { get; set; }

        public ProductMapper ProductMapper
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public StandardProduct(int productID, double price, string type, int supplierID)
        {
            ProductID = productID;
            Price = price;
            Type = type;
            SupplierID = supplierID;
        }

        public StandardProduct(double price, string type, int supplierID)
        {
            ProductID = 0;
            ProductMapper.GetProductID(this);
            Price = price;
            Type = type;
            SupplierID = supplierID;
        }

        override public string addProduct()
        {
           return ProductMapper.AddProduct(this);
        }


        override public string editProduct(double price, string type, int supplierID)
        {
            Price = price;
            Type = type;
            SupplierID = supplierID;
            return ProductMapper.editProduct(this);
        }

        override public string DeleteProduct()
        {
            return ProductMapper.DeleteProduct(this);
        }

        override public Product selectProduct(int pID)
        {
            return ProductMapper.SelectProduct(pID);
        }

        public static double getProductPrice(int pID)
        {
            return ProductMapper.getProductPrice(pID);
        }

    }
}
