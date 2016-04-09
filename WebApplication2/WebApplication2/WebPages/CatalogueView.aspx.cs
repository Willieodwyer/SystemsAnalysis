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
    public partial class CatalogueView : System.Web.UI.Page
    {
        static Catalogue catalogue = new Catalogue();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Products] ORDER BY ProductID", sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                GridView1.DataSource = reader;
                GridView1.DataBind();
                //Response.Write(Session["ID"].ToString());
            }
            catch (Exception sept)
            {
                Console.Write(sept.Message);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Products] WHERE Type = @SearchString", sqlConnection);//[Type] = " + Catalogue.Search(txtSearch.Text)

                sqlCommand.Parameters.Add("@SearchString", SqlDbType.NVarChar);
                sqlCommand.Parameters["@SearchString"].Value = Catalogue.Search(txtSearch.Text);

                Response.Write(Catalogue.Search(txtSearch.Text));
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                GridView2.DataSource = reader;
                GridView2.DataBind();
                //Response.Write(Session["ID"].ToString());
            }
            catch (Exception sept)
            {
                Console.Write(sept.Message);
            }
        }
    }
}