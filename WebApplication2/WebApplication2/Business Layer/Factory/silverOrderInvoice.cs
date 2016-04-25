using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication2.Business_Layer;

namespace WebApplication2
{
    public class silverOrderInvoice : iInvoice
    {
        public int orderID { get; set; }
        public int price;
        public int amount;
        public int custID;
        public int pID;
        public string address;
        public DateTime OrderDate;

        public silverOrderInvoice(int ID)
        {
            orderID = ID;
        }

        public void setPrice()
        {
            price = Convert.ToInt32(OrderMapper.GetOrderPrice(orderID));
        }

        public int getPrice()
        {
            return price;
        }

        public int getCustID() //return attr
        {
            return custID;
        }

        public void setCustID() //set attr
        {
            custID = OrderMapper.GetOrderCustID(orderID);
        }

        public int getProductID() //return attr
        {
            return pID;
        }

        public void setProductID() //set attr
        {
            pID = OrderMapper.GetOrderProductID(orderID);
        }

        public string getAddress() //return attr
        {
            return address;
        }

        public void setAddress() //set attr
        {
            address = OrderMapper.GetOrderAddress(orderID);
        }

        public DateTime getDate() //return attr
        {
            return OrderDate;
        }

        public void setDate() //set attr
        {
            OrderDate = OrderMapper.GetOrderDate(orderID);
        }

        public void print()
        {
            string filename = orderID + ".txt";
            string directory = @"C:\Invoices\";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = directory + filename;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Silver Invoice: ");
                    sw.WriteLine(" ");
                    sw.WriteLine("Order Number: " + orderID);
                    sw.WriteLine("Address: " + address);
                    sw.WriteLine("Product Number: " + pID);
                    sw.WriteLine("Customer ID: " + custID);
                    sw.WriteLine("Amount: " + price);
                    sw.WriteLine("");
                    sw.WriteLine("Please retain this invoice for your records.");
                }
                System.Diagnostics.Process.Start(path);
            }
            else
                System.Diagnostics.Process.Start(path); 

        }
    }
}
