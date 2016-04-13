\using System;
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
    public class OrderMapper
    {
        public static string GetOrderID(Order ord){
            int oID = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString); 
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT OrderID FROM [Order] WHERE OrderID = (SELECT MAX(OrderID) FROM [Order])", con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oID = Convert.ToInt32(reader["OrderID"]);
                    oID++;
                }
                reader.Close();
                ord.OrderID = oID;

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            finally
            {
                con.Close();
            }
            return "complete";
        }

        public static string CreateOrder(Order ord)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "INSERT INTO [Order] VALUES(@OrderID ,@CustomerID, @ProductID, @Address, @Amount, @OrderDate, @SupplierID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (ord.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = ord.OrderID;

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = ord.CustomerID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = ord.ProductID;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = ord.Address;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = ord.Amount;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = ord.Date;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = ord.SupplierID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "complete";
                }
                else
                    return "ProductID <= 0 for some reason - OrderMapper";

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }

        public static string EditOrder(Order ord)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "UPDATE [Order] SET CustomerID = @CustomerID, ProductID = @ProductID," +
                                "Address = @Address, Amount = @Amount,  OrderDate = @OrderDate, SupplierID = @SupplierID WHERE OrderID = @OrderID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (ord.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = ord.CustomerID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = ord.ProductID;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = ord.Address;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = ord.Amount;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = ord.Date;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = ord.SupplierID;

                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            return "Edit Order COmpleted";
        }

        public static string AddProduct(Order ord, int pID, double amnt)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "INSERT INTO [Order] VALUES(@OrderID ,@CustomerID, @ProductID, @Address, @Amount, @OrderDate, @SupplierID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (ord.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = ord.OrderID;

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = ord.CustomerID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = pID;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = ord.Address;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = amnt;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = ord.Date;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = ord.SupplierID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Add product completed";
                }
                else
                    return "Add product - Prod ID < 1";

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }

        public static string RemoveProduct(Order ord, int pID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "DELETE FROM [Order] WHERE [OrderID] = @OrderID AND [ProductID] = @ProductID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (ord.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = ord.OrderID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = pID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "remove product completed";
                }
                else
                    return "ProductID < 1 - remove product";

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }
    }
}