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
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
                int quantity = Convert.ToInt32(txtQuantity.Text);
                txtPrice.Text = "1";
                double price = Convert.ToDouble(txtPrice.Text);

                String sql = "INSERT INTO [Order] VALUES(@CustomerID, @ProductID, @Address, @Amount, @OrderDate, @SupplierID)";

                //if there is an error with the data it will catch the exception and display an error
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = DBNull.Value;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = lstProducts.SelectedItem.Value;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = DBNull.Value;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = price;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = DateTime.Now;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = DBNull.Value;

                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("Order processed!!");
                }
                catch (SqlException sqlEx)
                {
                    Response.Write(sqlEx.Message);
                }
                finally
                {
                    connection.Close();
                    Response.Redirect("OrderView.aspx?ID=" + lstProducts.SelectedValue.ToString());
                }

            }

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

        private void FillProductList()
        {
            lstProducts.Items.Clear();
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
    }


}
