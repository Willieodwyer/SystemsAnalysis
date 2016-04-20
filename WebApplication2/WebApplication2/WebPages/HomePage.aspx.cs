﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;



namespace WebApplication2.WebPages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static Customer newCust;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool checkDetails(string email, string password)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlDataReader reader;
            bool valid = false;
            String[] parseID = email.Split('@');

            String sql = "SELECT * FROM Customer WHERE EmailAddress = @email AND Password = @password";

            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters["@email"].Value = email;

            cmd.Parameters.Add("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = password;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                valid = true;
                while (reader.Read())
                {
                    newCust = new Customer(Convert.ToInt32(reader["CustomerID"]), reader["Name"].ToString(), reader["Address"].ToString(),
                        Convert.ToInt32(reader["PhoneNumber"]),reader["Notes"].ToString(),reader["EmailAddress"].ToString(),reader["Password"].ToString());
           
                }
            }
            connection.Close();
            return valid;

        }

        protected void Login(object sender, EventArgs e)
        {
            if (checkDetails(txtEmail.Text, txtPassword.Text))
                if (newCust != null)
                {
                    Session["CustObj"] = newCust;
                    Response.Redirect("Order.aspx", true);
                }
                else
                    loginSuccess.Text = "cust is null";
            else
                loginSuccess.Text = "Username/Password Incorrect!";
        }
    }
}