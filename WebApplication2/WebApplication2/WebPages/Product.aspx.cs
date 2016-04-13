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
    public partial class WebForm3 : System.Web.UI.Page
    {
        static Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Response.Write(FillProductList());
            }
        }

        private string FillProductList()
        {
            lstProducts.Items.Clear();
            ListItem baseItem = new ListItem();
            baseItem.Text = "New Product";
            baseItem.Value = "0";
            lstProducts.Items.Add(baseItem);

            string selectSQL = "SELECT * FROM [Products]";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = "Product ID:" + reader["Type"];
                    newItem.Value = reader["ProductID"].ToString();
                    lstProducts.Items.Add(newItem);
                }
                reader.Close();
                return "";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            finally
            {
                con.Close();
            }
        }


        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lstProducts.SelectedValue) > 0)
            {
                btnNewProduct.Enabled = false;
                btnEditProduct.Enabled = true;
                btnDeleteProduct.Enabled = true;
            }
            else
            {
                btnNewProduct.Enabled = true;
                btnEditProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;
                txtPrice.Text = "";
                txtType.Text = "";
                txtSupplier.Text = "";
            }


            string selectSQL = "SELECT * FROM [Products] WHERE ProductID = " + lstProducts.SelectedItem.Value;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtPrice.Text = reader["Price"].ToString();
                    txtType.Text = reader["Type"].ToString();
                    txtSupplier.Text = reader["SupplierID"].ToString();
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

        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            //public Product(double price,string type, int supplierID)
            Product prod = new Product(Convert.ToInt32(txtPrice.Text), txtType.Text, Convert.ToInt32(txtSupplier.Text));
            Response.Write(prod.addProduct());
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {
            Product prod = new Product(Convert.ToInt32(lstProducts.SelectedItem.Value), Convert.ToInt32(txtPrice.Text), txtPrice.Text, Convert.ToInt32(txtSupplier.Text));
            Response.Write(prod.editProduct(Convert.ToInt32(txtPrice.Text), txtType.Text, Convert.ToInt32(txtSupplier.Text)));
        }

        protected void btnViewProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogueView.aspx");
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product prod = new Product(Convert.ToInt32(lstProducts.SelectedItem.Value), Convert.ToInt32(txtPrice.Text), txtPrice.Text, Convert.ToInt32(txtSupplier.Text));
            Response.Write(prod.DeleteProduct());
        }

    }
}
