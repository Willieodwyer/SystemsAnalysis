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
    public class Supplier
    {
        public int SupplierID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public double PhoneNum { get; set; }
        public String Notes { get; set; }

        public Supplier(String name, String address, double phoneNum, String notes)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT SupplierID FROM [Supplier] WHERE SupplierID = (SELECT MAX(SupplierID) FROM [Supplier])", con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    SupplierID++;
                }
                reader.Close();

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            finally
            {
                con.Close();
            }
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
        }

        public string Add()
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            String sql = "INSERT INTO [Supplier] VALUES(@SupplierID ,@Name, @Address, @PhoneNum, @Notes)";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@SupplierID", SqlDbType.Int);
                command.Parameters["@SupplierID"].Value = this.SupplierID;

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = this.Name;

                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Address"].Value = this.Address;

                command.Parameters.Add("@PhoneNum", SqlDbType.Int);
                command.Parameters["@PhoneNum"].Value = this.PhoneNum;

                command.Parameters.Add("@Notes", SqlDbType.NVarChar);
                command.Parameters["@Notes"].Value = this.Notes;

                command.ExecuteNonQuery();
                connection.Close();
                return "Transaction Complete";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return sqlEx.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string Delete(int suppID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

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
            finally
            {
                connection.Close();
            }
        }

        public string Edit(int suppiD, String name, String address, int phoneNum, String notes)
        {
            //UPDATE table_name SET column1 = value1, column2 = value2...., columnN = valueN WHERE [condition];
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");
            //[Supplier] VALUES(@SupplierID ,@Name, @Address, @PhoneNum, @Notes)"
            String sql = "UPDATE [Supplier] SET Name = @Name, Address = @Address, PhoneNumber = @PhoneNumber, Notes = @Notes WHERE SupplierID = @SupplierID";

            //if there is an error with the data it will catch the exception and display an error
            try
            {
                if (this.SupplierID > 0)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = this.Name;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = this.Address;

                    command.Parameters.Add("@PhoneNumber", SqlDbType.Int);
                    command.Parameters["@PhoneNumber"].Value = this.PhoneNum;

                    command.Parameters.Add("@Notes", SqlDbType.NVarChar);
                    command.Parameters["@Notes"].Value = this.Notes;

                    command.Parameters.Add("@SupplierID", SqlDbType.Int);
                    command.Parameters["@SupplierID"].Value = suppiD;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Edit complete";
                }
                
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return sqlEx.Message;
            }
            return "Something really really went wrong";
        }
    }
}
