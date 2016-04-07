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
        public List<int> productList { get; set; }
        public List<int> customerList { get; set; }
        public List<double> discountList { get; set; }

        public Discount(int custClass)
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
                    productList.Add(Convert.ToInt32(reader["ProductID"]));
                    customerList.Add(Convert.ToInt32(reader["CustomerID"]));
                    discountList.Add(Convert.ToDouble(reader["discount"]));
                }
            }
            catch (SqlException sept)
            {
                Console.WriteLine(sept.Message);
            }

            customerClass = custClass;
        }

        public double applyDiscount(double A, int pID)
        {
            double Amount = A; 
            switch (customerClass)
            {
                case 1:
                    Amount =  A * 0.8;
                    break;
                case 2:
                    Amount = A * .8;
                    break;

                case 3:
                    Amount = A * .7;
                    break;

                case 4:
                    Amount = A * .6;
                    break;
            }
            switch (pID)
            {
                case 1:
                    Amount = Amount * .95;
                    break;
                case 2:
                    Amount = Amount * .9;
                    break;

                case 3:
                    Amount = Amount * .85;
                    break;
            }
            return A;
        }
    }

}
