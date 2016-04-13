using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class ProductMapper
    {
        public static void AddProductDB(Product p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "INSERT INTO [Products] VALUES(@Price, @Type,NULL)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@Price", SqlDbType.Float).Value = p.Price;

                command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = p.Type;

                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Success");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void editProductDB(string oldType, string manufacturer, string namebox, float Price)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "UPDATE [Products] SET Price = @Price, Type = @newType WHERE Type = @oldType";
            String newType = manufacturer + " " + namebox;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@Price", SqlDbType.Float);
                command.Parameters["@Price"].Value = Price;

                command.Parameters.Add("@newType", SqlDbType.NVarChar);
                command.Parameters["@newType"].Value = newType;

                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                connection.Close();
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
