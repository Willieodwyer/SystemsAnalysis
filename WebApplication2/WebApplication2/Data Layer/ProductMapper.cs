using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication2
{
    public class ProductMapper
    {
        public static string GetProductID(Product p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "INSERT INTO [Products] VALUES(@Price, @Type,NULL)";
            SqlConnection con = new SqlConnection(connectionString); 

            try
            {
            int pID = 0;
            SqlConnection con = new SqlConnection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT ProductID FROM [Product] WHERE OrderID = (SELECT MAX(ProductID) FROM [Product])", con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pID = Convert.ToInt32(reader["OrderID"]);
                    pID++;
                }
                reader.Close();
                p.ProductID = pID;

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


        public static string AddProduct(Product p)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [Product] VALUES(@ProductID ,@Price, @Type, @SupplierID, @Name)";
            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (p.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = p.ProductID;

                    command.Parameters.Add("@Price", SqlDbType.Float);
                    command.Parameters["@Price"].Value = p.Price;

                    command.Parameters.Add("@Type", SqlDbType.NVarChar);
                    command.Parameters["@Type"].Value = p.Type;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = p.SupplierID;

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = p.Name;

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

        public static string editProduct(Product p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 


            String sql = "UPDATE [Product] SET Price = @Price, Type = @Type," +
                                "SupplierID = @SupplierID, Name = @Name WHERE ProductID = @ProductID)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (p.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@Price", SqlDbType.Float);
                    command.Parameters["@Price"].Value = p.Price;

                    command.Parameters.Add("@Type", SqlDbType.NVarChar);
                    command.Parameters["@Type"].Value = p.Type;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = p.SupplierID;

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = p.Name;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = p.ProductID;

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

        public static string DeleteProduct(Product p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "DELETE FROM [Product] WHERE [Product] = @ProductID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (p.ProductID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters["@ProductID"].Value = p.ProductID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "delete product completed";
                }
                else
                    return "ProductID < 1 - delete product";

            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }

        public static Product SelectProduct(int pid){
            Product retProduct = null;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] WHERE ProductID = " + pid, con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    retProduct = new Product(Convert.ToInt32(reader["ProductID"]), (reader["Type"]).ToString(),
                        Convert.ToInt32(reader["SupplierID"]), (reader["Name"]).ToString());
                }
                reader.Close();
                con.Close();
                return retProduct;
            }
            catch (SqlException sqlEx)
            {
                Console.Write(sqlEx.Message);
                return null;
            }
        }

        public static double getProductPrice(int pID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "SELECT Price FROM [Products] WHERE ProductID = @ProductID";
            double price = 0.0;
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader;

            try
            {
                connection.Open();

                command.Parameters.Add("@ProductID", SqlDbType.Int);
                command.Parameters["@ProductID"].Value = pID;

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    price = reader.GetDouble(0);
                }

                reader.Close();
                return price;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return 0.0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
