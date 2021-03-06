﻿using System;
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
using MobilePhoneRetailer.BusinessLayer;
using MobilePhoneRetailer.DataLayer;


namespace MobilePhoneRetailer.BusinessLayer.Order
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Product Product { get; set; }
        public int SupplierID { get; set; }
        public String Address { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public OrderMapper OrderMapper { get; set; }
        public OrderDiscount OrderDiscount { get; set; }

        public Order(int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date)
        {
            OrderDiscount = new GoldOrderDiscount();
            OrderMapper.GetOrderID(this);
            CustomerID = customerID;
            Product = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount;
            Date = date;


            OrderDiscount.applyDiscount(this);
        }

        public string CreateOrder()
        {
            return OrderMapper.CreateOrder(this);
        }

        public string EditOrder(int orderID, int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date)
        {
            //UPDATE table_name SET column1 = value1, column2 = value2...., columnN = valueN WHERE [condition];
            OrderID = orderID;
            CustomerID = customerID;
            Product = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount;
            Date = date;
            return OrderMapper.EditOrder(this);

        }

        public string AddProduct(int pID, double amnt)
        {
            return OrderMapper.AddProduct(this, pID, amnt);
        }


        public string RemoveProduct(int pID)
        {
            return OrderMapper.RemoveProduct(this, pID);
        }

        public string PrintOrder()
        {
            string retString = "";
            try
            {
                string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Order] WHERE OrderID = " + this.OrderID, sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    //OrderID	CustomerID	ProductID	Address	Amount	OrderDate	SupplierID
                    retString = retString + reader["OrderID"] + "," + reader["CustomerID"]
                    + "," + reader["ProductID"] + "," + reader["Address"] + "," + reader["Amount"] + "," + reader["OrderDate"] + "," + reader["SupplierID"];
                }
                return retString;
            }
            catch (SqlException sept)
            {
                return sept.Message;
            }
        }
    }
}