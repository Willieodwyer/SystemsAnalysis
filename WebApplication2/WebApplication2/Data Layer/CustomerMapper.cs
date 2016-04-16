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
    public class CustomerMapper
    {

        public static string getCustomerID(Customer cust)
        {
            int customerID = 0;
            String sql = "SELECT MAX(CustomerID) as MAX FROM [Customer]";
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
                    customerID = reader.GetInt32(reader.GetOrdinal("MAX"));
                }
                customerID++;
                cust.CustomerID = customerID;
                reader.Close();
            }
            catch (SqlException sqlEx)
            {
                return sqlEx.Message;
            }
            finally
            {
                connection.Close();
            }
            return "Complete";
            
        }

        public static string AddCustomer(Customer cust)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "INSERT INTO [Customer] VALUES(@CustomerID, @Name, @Address, @PhoneNumber, @Notes, @Username, @Password)";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cust.CustomerID;

                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = cust.Name;

                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = cust.Address;

                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = cust.PhoneNum;

                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = cust.Notes;

                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = cust.Username;

                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = cust.Password;

                command.ExecuteNonQuery();
                connection.Close();
                return "Complete";

            }
            catch (SqlException sqlEx)
            {
                return(sqlEx.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static string EditCustomer(Customer cust)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "UPDATE [Customer] SET CustomerID = @CustomerID, Name = @Name, Address = @Address, " +
                " PhoneNumber = @PhoneNumber, Notes = @Notes, Username = @Username, Password = @Password";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cust.CustomerID;

                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = cust.Name;

                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = cust.Address;

                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = cust.PhoneNum;

                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = cust.Notes;

                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = cust.Username;

                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = cust.Password;

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

        public static string DeleteCustomer(Customer cust)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "DELETE FROM [Customer] WHERE [CustomerID] = @CustomerID";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@OrderID", SqlDbType.Int);
                command.Parameters["@OrderID"].Value = cust.CustomerID;

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
    }
}
