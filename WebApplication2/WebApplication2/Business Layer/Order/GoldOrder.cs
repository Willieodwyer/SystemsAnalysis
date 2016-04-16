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



namespace WebApplication2
{
    public class GoldOrder : Order
    {
        override public int OrderID { get; set; }
        override public int CustomerID { get; set; }
        override public Product Product { get; set; }
        override public int SupplierID { get; set; }
        override public String Address { get; set; }
        override public double Amount { get; set; }
        override public DateTime Date { get; set; }

        public GoldOrder(int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date)
        {
            OrderMapper.GetOrderID(this);
            CustomerID = customerID;
            Product = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount * 0.80;
            Date = date;
        }
        
        override public string CreateOrder()
        {
            return OrderMapper.CreateOrder(this);
        }

        override public string EditOrder(int orderID, int customerID, Product productID, int supplierID, String address, double amount,
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

        override public string AddProduct(int pID, double amnt)
        {
            return OrderMapper.AddProduct(this, pID, amnt);
        }


        override public string RemoveProduct(int pID)
        {
            return OrderMapper.RemoveProduct(this, pID);
        }

        override public string PrintOrder()
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