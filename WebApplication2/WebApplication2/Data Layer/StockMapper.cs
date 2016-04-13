using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class StockMapper
    {
        public static void addStockDB(int ProductID, int Quantity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "INSERT INTO [Stock] VALUES(@ProductID, @Quantity)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;

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

        public static void updateStockBD(int ProductID, int Quantity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "UPDATE [Stock] SET Quantity = @Quantity WHERE ProductID = @ProductID";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@Quantity", SqlDbType.Int);
                command.Parameters["@Quantity"].Value = Quantity;

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
    }
}
