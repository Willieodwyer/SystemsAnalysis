using System;
using System.Collections.Generic;
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Windows 8\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
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
            catch(SqlException sqlEx)
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Windows 8\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
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
    }
}
