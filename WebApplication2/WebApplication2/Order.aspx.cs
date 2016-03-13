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

namespace WebApplication2
{
    public partial class Order1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
                string product = txtProduct.Text.Trim();
                int quantity = Convert.ToInt32(txtQuantity.Text);
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
                    command.Parameters["@ProductID"].Value = DBNull.Value;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = "Somewhere better than here";

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
    }
}