using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int PhoneNum { get; set; }
        public String Notes { get; set; }

        public String Username { get; set; }
        public String Password { get; set; }

        public Customer(int customerID, String name, String address, int phoneNum, String notes, String username,
                        String password)
        {
            String sql = "SELECT MAX(CustomerID) as MAX FROM [Customer]";
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
                    customerID = reader.GetInt32(reader.GetOrdinal("MAX"));
                }
                customerID++;
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
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
            Username = username;
            Password = password;
        }

        public void AddCustomer()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "INSERT INTO [Customer] VALUES(@CustomerID, @Name, @Address, @PhoneNumber, @Notes, @Username, @Password)";

            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = this.CustomerID;

                command.Parameters.Add("@Name", SqlDbType.Int).Value = this.Name;

                command.Parameters.Add("@Address", SqlDbType.Int).Value = this.Address;

                command.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = this.PhoneNum;

                command.Parameters.Add("@Notes", SqlDbType.Int).Value = this.Notes;

                command.Parameters.Add("@Password", SqlDbType.Int).Value = this.Username;

                command.ExecuteNonQuery();
                connection.Close();
                
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
            finally
            {
                connection.Close();
            }
        }
        public void EditCustomer(int customerID, String name, String address, int phoneNum, String notes, String username,
                        String password)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
            Username = username;
            Password = password;
        }

        public bool DeleteCustomer()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jack\Desktop\Systems Analysis Project\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

            String sql = "DELETE FROM [Customer] WHERE [CustomerID] = @CustomerID";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@OrderID", SqlDbType.Int);
                command.Parameters["@OrderID"].Value = this.CustomerID;

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
    }
}