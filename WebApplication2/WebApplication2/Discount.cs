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

//@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\workarea\SystemsAnalysis-master\SystemsAnalysis-master\WebApplication2\WebApplication2\App_Data\Database2.mdf;Integrated Security=True"
namespace WebApplication2
{
    public class Discount
    {
        public int customerClass { get; set; }

        double discount;

        public Discount(int custClass , int pID)
        {
            try
            {
                string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\workarea\SystemsAnalysis-master\SystemsAnalysis-master\WebApplication2\WebApplication2\App_Data\Database2.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Discount]";
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    //OrderID	CustomerID	ProductID	Address	Amount	OrderDate	SupplierID
                    if(pID == Convert.ToInt32(reader["ProductID"])){
                        discount = Convert.ToDouble(reader["discount"]);
                    }
                    else if(custClass == Convert.ToInt32(reader["CustomerID"])){
                        discount = Convert.ToDouble(reader["discount"]);
                    }
                    else
                        discount = 1;
                }
            }
            catch (SqlException sept)
            {
                Console.WriteLine(sept.Message);
            }

            customerClass = custClass;
        }

        public double applyDiscount(double A)
        {
            return A * discount;
        }
    }

}
