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
    public class ProductDiscount
    {
        public double discount { get; set; }
        public Product prod {get;set;}

        public ProductDiscount(Product p)
        {
            prod = p;
            discount = .8;
        }

        public double applyDiscount()
        {
            discount = 1;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [ProductDiscount]", sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    //OrderID	CustomerID	ProductID	Address	Amount	OrderDate	SupplierID
                    if (prod.ProductID == Convert.ToInt32(reader["ProductID"]))
                    {
                        discount = Convert.ToDouble(reader["Discount"]);
                    }
                }
                return discount * prod.Price;
            }
            catch (SqlException sept)
            {
                Console.WriteLine(sept.Message);
                return 2;
            }
        }
    }

}
