using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Register_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            String email = EmailBox.Text;
            String password = PasswordBox.Text;
            String name = NameBox.Text;
            String address = AddressBox.Text;
            String Num = PhoneNumBox.Text;
            int phoneNum = Convert.ToInt32(Num);
            String notes = "notes test";

            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\Users\Windows 8\Documents\Visual Studio 2013\Projects\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True");

                String sql = "INSERT INTO Customer VALUES(@Name, @Address, @PhoneNumber, @Notes, @EmailAddress, @Password)";
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = name;

                command.Parameters.Add("@Address", SqlDbType.VarChar);
                command.Parameters["@Address"].Value = address;

                command.Parameters.Add("@PhoneNumber", SqlDbType.Int);
                command.Parameters["@PhoneNumber"].Value = phoneNum;

                command.Parameters.Add("@Notes", SqlDbType.VarChar);
                command.Parameters["@Notes"].Value = notes;

                command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                command.Parameters["@EmailAddress"].Value = email;

                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = password;

                command.ExecuteNonQuery();
                connection.Close();
            }

           catch
           {
                Response.Write("FAIL");
           }
        }
    }
}