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
    public class SupplierMapper
    {
        public static string GetSupplierID(Supplier supp)
        {
            int sID = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString); 
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT SupplierID FROM [Supplier] WHERE SupplierID = (SELECT MAX(SupplierID) FROM [Supplier])", con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sID = Convert.ToInt32(reader["SupplierID"]);
                    sID++;
                }
                supp.SupplierID = sID;
                reader.Close();
                con.Close();
                return "Success";
            }
            catch (SqlException sqlEx)
            {
                return (sqlEx.Message);
            }
        }


        public static string Add(Supplier supp)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString); 
            String sql = "INSERT INTO [Supplier] VALUES(@SupplierID ,@Name, @Address, @PhoneNum, @Notes)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@SupplierID", SqlDbType.Int);
                command.Parameters["@SupplierID"].Value = supp.SupplierID;

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = supp.Name;

                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Address"].Value = supp.Address;

                command.Parameters.Add("@PhoneNum", SqlDbType.Int);
                command.Parameters["@PhoneNum"].Value = supp.PhoneNum;

                command.Parameters.Add("@Notes", SqlDbType.NVarChar);
                command.Parameters["@Notes"].Value = supp.Notes;

                command.ExecuteNonQuery();
                connection.Close();
                return "Transaction Complete";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return sqlEx.Message;
            }
        }

        public static string Delete(int suppID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            String sql = "DELETE FROM [Supplier] WHERE SupplierID = @SupplierID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (suppID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = suppID;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Delete complete";
                }
                else
                    return "Supplier ID !> 0";

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return sqlEx.Message;
            }
        }

        public static string Edit(Supplier supp,int suppiD, String name, String address, int phoneNum, String notes)
        {
            //UPDATE table_name SET column1 = value1, column2 = value2...., columnN = valueN WHERE [condition];
            supp.Name = name;
            supp.Address = address;
            supp.PhoneNum = phoneNum;
            supp.Notes = notes;

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //[Supplier] VALUES(@SupplierID ,@Name, @Address, @PhoneNum, @Notes)"
            String sql = "UPDATE [Supplier] SET Name = @Name, Address = @Address, PhoneNumber = @PhoneNumber, Notes = @Notes WHERE SupplierID = @SupplierID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (supp.SupplierID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = supp.Name;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = supp.Address;

                    command.Parameters.Add("@PhoneNumber", SqlDbType.Int);
                    command.Parameters["@PhoneNumber"].Value = supp.PhoneNum;

                    command.Parameters.Add("@Notes", SqlDbType.NVarChar);
                    command.Parameters["@Notes"].Value = supp.Notes;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = suppiD;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Edit complete";
                }
                else
                    return "SupplierID < 1";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return sqlEx.Message;
            }
        }
    }
}