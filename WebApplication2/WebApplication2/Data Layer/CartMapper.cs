using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class CartMapper
    {

        public static string getCartID(Cart cart)
        {
            int cartID = 0;
            String sql = "SELECT MAX(CartID) as MAX FROM [ShoppingCart]";
           
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
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
                cart.CartID = cartID;
                reader.Close();
                return "Complete";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public static string CreateCart(Cart cart)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "INSERT INTO [ShoppingCart] VALUES(@CustomerID, NULL, NULL, @CartID)";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CartID", SqlDbType.Int);
                command.Parameters["@CartID"].Value = cart.CartID;

                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = cart.CustomerID;

                command.ExecuteNonQuery();
                connection.Close();
                return "Complete";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }


        public static string EditCart(Cart cart)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "UPDATE[ShoppingCart] SET CustomerID = @CustomerID, ProductID = NULL, Quantity = NULL, CartID = @CartID";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CartID", SqlDbType.Int);
                command.Parameters["@CartID"].Value = cart.CartID;

                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = cart.CustomerID;

                command.ExecuteNonQuery();
                connection.Close();
                return "Complete";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }

        public static string AddToCart(Cart cart, int productID, int quantity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "INSERT INTO [ShoppingCart] VALUES(@CustomerID, @CartID, @ProductID, @Quantity)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);


                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cart.CustomerID;

                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

                command.Parameters.Add("@CartID", SqlDbType.Int).Value = cart.CartID;

                command.ExecuteNonQuery();
                connection.Close();

                return "Complete";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static string RemoveFromCart(Cart cart, int productID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "DELETE FROM [ShoppingCart] WHERE CustomerID = @CustomerID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = cart.CustomerID;

                command.Parameters.Add("@ProductID", SqlDbType.Int);
                command.Parameters["@ProductID"].Value = productID;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                return "Complete";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static double getTotal(Cart cart)
        {
            double total = 0.0;
            int cartID = cart.CartID;
            List<int> pIDs = new List<int>();
            List<int> quantities = new List<int>();
           
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            String sql = "SELECT ProductID, Quantity FROM [ShoppingCart] WHERE CartID = @CartID";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader;


            connection.Open();

            command.Parameters.Add("@CartID", SqlDbType.Int);
            command.Parameters["@CartID"].Value = cart.CartID;

            reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    pIDs.Add(reader.GetInt32(0));
                    quantities.Add(reader.GetInt32(1));
                }
                reader.NextResult();
            }


            connection.Close();


            for (int i = 0; i < pIDs.Count; i++)
            {
                total += Product.getProductPrice(pIDs[i]) * quantities[i];
            }

            return total;
        }

    }
}