using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication2.Business_Layer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oID = OrderDropDownList.SelectedValue;
            int orderID = Convert.ToInt32(oID);

            string category = RadioButtonList1.SelectedValue;
            if(category == "Gold")
            {
                goldOrderInvoice inv = goldOrderInvoice.createGoldInvoice(orderID);

                inv.setPrice();
                inv.setCustID();
                inv.setProductID();
                inv.setAddress();

                string filename = oID + ".txt";
                string path = @"C:\" + filename;
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Gold Invoice: ");
                        sw.WriteLine(" ");
                        sw.WriteLine("Order Number: " + oID);
                        sw.WriteLine("Address: " + inv.getAddress());
                        sw.WriteLine("Product Number: " + inv.getProductID());
                        sw.WriteLine("Customer ID: " + inv.getCustID());
                        sw.WriteLine("Amount: " + inv.getPrice());
                        sw.WriteLine("");
                        sw.WriteLine("Please retain this invoice for your records.");
                    }
                    System.Diagnostics.Process.Start(path);
                }
                else
                    System.Diagnostics.Process.Start(path);
            }

            else if(category == "Silver")
            {
                silverOrderInvoice inv = silverOrderInvoice.createSilverInvoice(orderID);

                inv.setPrice();
                inv.setCustID();
                inv.setProductID();
                inv.setAddress();

                string filename = oID + ".txt";
                string path = @"C:\Users\Windows 8\Documents\VStest\" + filename;
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Silver Invoice: ");
                        sw.WriteLine(" ");
                        sw.WriteLine("Order Number: " + oID);
                        sw.WriteLine("Address: " + inv.getAddress());
                        sw.WriteLine("Product Number: " + inv.getProductID());
                        sw.WriteLine("Customer ID: " + inv.getCustID());
                        sw.WriteLine("Amount: " + inv.getPrice());
                        sw.WriteLine("");
                        sw.WriteLine("Please retain this invoice for your records.");
                    }
                    System.Diagnostics.Process.Start(path);
                }
                else
                    System.Diagnostics.Process.Start(path);
            }

            else
            {
                standardOrderInvoice inv = standardOrderInvoice.createStdInvoice(orderID);

                inv.setPrice();
                inv.setCustID();
                inv.setProductID();
                inv.setAddress();

                string filename = oID + ".txt";
                string path = @"C:\" + filename;
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Standard Invoice: ");
                        sw.WriteLine(" ");
                        sw.WriteLine("Order Number: " + oID);
                        sw.WriteLine("Address: " + inv.getAddress());
                        sw.WriteLine("Product Number: " + inv.getProductID());
                        sw.WriteLine("Customer ID: " + inv.getCustID());
                        sw.WriteLine("Amount: " + inv.getPrice());
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
}