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
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public String Address { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Order(int customerID, int productID, int supplierID, String address, double amount,
            DateTime date)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT OrderID FROM [Order] WHERE OrderID = (SELECT MAX(OrderID) FROM [Order])", con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderID = Convert.ToInt32(reader["OrderID"]);
                    OrderID++;
                }
                reader.Close();

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                con.Close();
            }
            CustomerID = customerID;
            ProductID = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount;
            Date = date;
        }

        public bool CreateOrder()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [Order] VALUES(@OrderID ,@CustomerID, @ProductID, @Address, @Amount, @OrderDate, @SupplierID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (this.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = this.OrderID;

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = this.CustomerID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = this.ProductID;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = this.Address;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = this.Amount;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = this.Date;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = this.SupplierID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                else
                    return false;

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void EditOrder(int orderID, int customerID, int productID, int supplierID, String address, double amount,
            DateTime date)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            SupplierID = supplierID;
            Address = address;
            Amount = amount;
            Date = date;
        }

        public bool AddProduct(int pID, int amnt)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [Order] VALUES(@OrderID ,@CustomerID, @ProductID, @Address, @Amount, @OrderDate, @SupplierID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (this.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = this.OrderID;

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = this.CustomerID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = pID;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = this.Address;

                    command.Parameters.Add("@Amount", SqlDbType.Float);
                    command.Parameters["@Amount"].Value = amnt;

                    command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                    command.Parameters["@OrderDate"].Value = this.Date;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = this.SupplierID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                else
                    return false;

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public bool RemoveProduct(int pID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "DELETE FROM [Order] WHERE [OrderID] = @OrderID AND [ProductID] = @ProductID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (this.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@OrderID", SqlDbType.Int);
                    command.Parameters["@OrderID"].Value = this.OrderID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = pID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                else
                    return false;

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
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
                Console.WriteLine(sept.Message);
            }
        }
    }
}