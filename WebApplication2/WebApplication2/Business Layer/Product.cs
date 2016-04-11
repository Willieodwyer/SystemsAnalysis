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
        //public int ProductID { get; set; }
        public String Manufacturer { get; set; }
        public String Name { get; set; }
        public float Price { get; set; }
        public String Type { get; set; }

        public Product(String manufacturer, String name, float price)
        {
            //ProductID = productID;
            Manufacturer = manufacturer; 
            Name = name;
            Type = Manufacturer + " " + Name; //type is manufacturer + name
            Price = price;
        }

        public void addProduct()
        {
           ProductMapper.AddProductDB(this);
        }


        public void editProduct(string oldType,string manufacturer,string namebox,float Price)
        {
          
        }

        public void selectProduct()
        {

        }
    }
}
