using System;
using System.Collections.Generic;
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Windows 8\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Windows 8\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
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
