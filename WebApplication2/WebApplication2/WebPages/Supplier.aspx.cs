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


namespace WebApplication2.WebPages
{
    public partial class AddSupplier : System.Web.UI.Page
    {

        static Supplier newSupp;

        public WebApplication2.Supplier Supplier
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
                txtNotes.Text = "";
            }
        }


        private void FillProductList()
        {
            lstSuppliers.Items.Clear();
            ListItem baseItem = new ListItem();
            baseItem.Text = "New Supplier";
            baseItem.Value = "0";
            lstSuppliers.Items.Add(baseItem);

            string selectSQL = "SELECT SupplierID FROM [Supplier]";

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
                    newItem.Text = "Supplier ID:" + reader["SupplierID"];
                    newItem.Value = reader["SupplierID"].ToString();
                    lstSuppliers.Items.Add(newItem);
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
            if (Convert.ToInt32(lstSuppliers.SelectedValue) > 0)
            {
                btnNewSupplier.Enabled = false;
                btnEditSupplier.Enabled = true;
                btnDeleteSupplier.Enabled = true;
            }
            else
            {
                btnNewSupplier.Enabled = true;
                btnEditSupplier.Enabled = false;
                btnDeleteSupplier.Enabled = false;
                txtAddress.Text = "";
                txtName.Text = "";
                txtNotes.Text = "";
                txtPhoneNum.Text = "";
            }


            string selectSQL = "SELECT * FROM [Supplier] WHERE SupplierID = " + lstSuppliers.SelectedItem.Value;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtPhoneNum.Text = reader["PhoneNumber"].ToString();
                    txtNotes.Text = reader["Notes"].ToString();
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

        protected void btnSupplier_Click(object sender, EventArgs e)
        {
            newSupp = new Supplier(txtName.Text,txtAddress.Text,Convert.ToInt32(txtPhoneNum.Text),txtNotes.Text);
            Response.Write(newSupp.Add());
        }

        protected void btnEditSupplier_Click(object sender, EventArgs e)
        {
            newSupp = new Supplier(txtName.Text, txtAddress.Text, Convert.ToInt32(txtPhoneNum.Text), txtNotes.Text);
            Response.Write(newSupp.Edit(Convert.ToInt32(lstSuppliers.SelectedValue), txtName.Text, txtAddress.Text, Convert.ToInt32(txtPhoneNum.Text), txtNotes.Text));
        }

        protected void btnViewSuppliers_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierView.aspx");
        }

        protected void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            Response.Write(Supplier.Delete(Convert.ToInt32(lstSuppliers.SelectedValue)));
        }
    }
}