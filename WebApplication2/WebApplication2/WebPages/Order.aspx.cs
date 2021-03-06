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
using MobilePhoneRetailer.BusinessLayer.Order;

namespace MobilePhoneRetailer.WebPages
{
    public partial class Order1 : System.Web.UI.Page
    {
        static Order newOrder;
        static Product newProduct;
        static Customer sessionCust;
        double price;

        public Product Product
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ProductDiscount ProductDiscount
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Order Order
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FillProductList();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {//Convert.ToInt32(lstProducts.SelectedValue), Convert.ToInt32(txtPrice.Text), 1)
                sessionCust = (Customer)Session["CustObj"];
                newProduct = new StandardProduct(Convert.ToInt32(lstProducts.SelectedValue), Convert.ToDouble(txtPrice.Text), lstProducts.SelectedItem.Text, 1);
                ProductDiscount pd = new ProductDiscount(newProduct);
                if (sessionCust != null)
                {
                    Response.Write("Calculating Individual Product DIscount - " + pd.applyDiscount() + "/" + newProduct.Price + " Pid = " + newProduct.ProductID + "\n");
                    newOrder = new Order(
                    sessionCust.CustomerID,
                    newProduct,
                    1,
                    txtAddress.Text,
                    pd.applyDiscount() * Convert.ToInt32(txtQuantity.Text),
                    DateTime.Now);
                    newOrder.CreateOrder();

                    Response.Write("Order processed!!\n\n\n\n");
                    btnOrder.Enabled = false;
                    btnAddOrder.Enabled = true;
                    btnViewOrder.Enabled = true;
                    Response.Write("Calculating Customer Discount - " + newOrder.Amount +
                        "/" + (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text)) + "\n");
                    Session["OrderObj"] = newOrder;
                }
                else
                    Response.Write("No customer is in session, please log in");

            }

        }

        private void FillProductList()
        {
            lstProducts.Items.Clear();
            ListItem baseItem = new ListItem();
            baseItem.Text = "Please select a product";
            baseItem.Value = "0";
            lstProducts.Items.Add(baseItem);

            string selectSQL = "SELECT * FROM [Products]";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = "Product:" + reader["Type"];
                    newItem.Value = reader["ProductID"].ToString();
                    lstProducts.Items.Add(newItem);
                    //Product localProd = new Product(reader["Type"].ToString(), reader["Name"].ToString(), Convert.ToDouble(reader["Price"]));
                    //productList.Add(localProd);
                }
                reader.Close();
            }
            catch (SqlException sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectSQL = "SELECT * FROM [Products] WHERE ProductID = " + lstProducts.SelectedItem.Value;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtPrice.Text = reader["Price"].ToString();
                    price = Convert.ToDouble(txtPrice.Text);
                }
                reader.Close();

            }
            catch (Exception sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                con.Close();
            }

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            //Customer cust = (Customer) Session["CustomerOBJ"];
            if (newOrder != null)
            {
                newProduct = new StandardProduct(Convert.ToInt32(lstProducts.SelectedValue), Convert.ToDouble(txtPrice.Text), lstProducts.SelectedItem.Text, 1);
                ProductDiscount pd = new ProductDiscount(newProduct);
                Response.Write("Calculating Individual Product DIscount - " + pd.applyDiscount() + "/" + newProduct.Price + " Pid = " + newProduct.ProductID + "\n");

                newOrder.AddProduct(
                    newProduct.ProductID,
                    pd.applyDiscount() * Convert.ToInt32(txtQuantity.Text));
                Response.Write("Product processed!!\n \n ");
                Response.Write("Calculating Customer Discount - " + newOrder.Amount +
                    "/" + (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text)) + "\n");
            }
            else
                Response.Write("new order is null????");
        }

        protected void btnViewOrder_Click(object sender, EventArgs e)
        {
            Session["ID"] = newOrder.OrderID;
            Session["OrderOBJ"] = newOrder;
            Response.Redirect("OrderView.aspx");
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
