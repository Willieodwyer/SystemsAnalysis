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
using MobilePhoneRetailer.BusinessLayer.Order;

namespace MobilePhoneRetailer.WebPages
{
    public partial class OrderView : System.Web.UI.Page
    {
        public Order Order
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //Order sentOrder = (Order) Session["OrderOBJ"];
            //Response.Write(sentOrder.PrintOrder());
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            
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