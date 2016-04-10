using System;
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
    public partial class Order1 : System.Web.UI.Page
    {
        static Order newOrder;
        double price;
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
            {
                newOrder = new StandardOrder(1, Convert.ToInt32(lstProducts.SelectedValue), 1, "Somewhere Land", 
                    Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text), DateTime.Now);
                newOrder.CreateOrder();

                Response.Write("Order processed!!");
                btnOrder.Enabled = false;
                btnAddOrder.Enabled = true;
                btnViewOrder.Enabled = true;
            }

        }

        private void FillProductList()
        {
            lstProducts.Items.Clear();
            ListItem baseItem = new ListItem();
            baseItem.Text = "Please select a product";
            baseItem.Value = "0";
            lstProducts.Items.Add(baseItem);

            string selectSQL = "SELECT ProductID FROM [Products]";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = "Product:" + reader["ProductID"];
                    newItem.Value = reader["ProductID"].ToString();
                    lstProducts.Items.Add(newItem);
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
            string selectSQL = "SELECT Price FROM [Products] WHERE ProductID = " + lstProducts.SelectedItem.Value;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
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
            catch (SqlException sqlEx)
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
            Discount disc = new Discount(1,1);
            if (newOrder != null)
            {
                newOrder.AddProduct(
                    Convert.ToInt32(lstProducts.SelectedValue), 
                    disc.applyDiscount(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text))
                    );

                Response.Write("Product processed!!");
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

    }

}
