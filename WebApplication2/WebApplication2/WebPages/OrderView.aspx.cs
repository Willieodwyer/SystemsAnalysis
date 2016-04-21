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
//Session["CustObj"] = newCust;
//sessionCust = (Customer)Session["CustObj"];
namespace WebApplication2.WebPages
{
    public partial class OrderView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Order sentOrder = (Order) Session["OrderOBJ"];
            //Response.Write(sentOrder.PrintOrder());
            try
            {
                string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\werl\Documents\Visual Studio 2013\Projects\SystemsAnalysis\WebApplication2\WebApplication2\App_Data\Database.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                Order sessionOrd = (Order)Session["OrderObj"];
                SqlCommand sqlCommand;
                if (sessionOrd == null)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM [Order] ORDER BY OrderID", sqlConnection);// WHERE OrderID = " + Session["ID"].ToString(), sqlConnection);
                }
                else
                    sqlCommand = new SqlCommand("SELECT * FROM [Order] WHERE [OrderID] = " + sessionOrd.OrderID, sqlConnection);

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                GridView1.DataSource = reader;
                GridView1.DataBind();
                //Response.Write(Session["ID"].ToString());
            }
            catch (Exception sept)
            {
                Response.Write(sept.Message);
            }
        }
    }
}