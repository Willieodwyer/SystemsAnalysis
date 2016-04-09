using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Cart
    {
        public int CustomerID { get; set; }
        public int CartID { get; set; }


        public Cart(int customerID, int cartID)
        {
            String sql = "SELECT MAX(CartID) as MAX FROM [ShoppingCart]";
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader;
            command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cartID = reader.GetInt32(reader.GetOrdinal("MAX"));
                }
                cartID++;
                reader.Close();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }
            CustomerID = customerID;
            CartID = cartID;
        }

        public bool CreateCart()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [ShoppingCart] VALUES(@CustomerID, NULL, NULL, @CartID)";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CartID", SqlDbType.Int);
                command.Parameters["@CartID"].Value = this.CartID;

                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = this.CustomerID;

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
                return false;
            }
        }


        public void EditCart(int customerID, int cartID)
        {
            CustomerID = customerID;
            CartID = cartID;
        }

        public bool AddToCart(int productID, int quantity)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [ShoppingCart] VALUES(@CustomerID, @ProductID, @Quantity, @CartID)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);


                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = this.CustomerID;

                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

                command.Parameters.Add("@CartID", SqlDbType.Int).Value = this.CartID;

                command.ExecuteNonQuery();
                connection.Close();

                return true;
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

        public void RemoveFromCart(int productID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "DELETE FROM [ShoppingCart] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = this.CustomerID;

                command.Parameters.Add("@ProductID", SqlDbType.Int);
                command.Parameters["@ProductID"].Value = productID;

                connection.Open();
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