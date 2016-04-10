using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Product
    {
        public String Manufacturer { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }

        public Product(String manufacturer, String name, double price)
        {
            Manufacturer = manufacturer;
            Name = name;
            Price = price;
        }
    }
}