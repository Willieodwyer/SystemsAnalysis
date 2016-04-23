using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.WebPages
{
    public partial class CartView : System.Web.UI.Page
    {
        static OrderContext newOrder;
        static Product newProduct;
        static Cart cart;
        static Customer sessionCust;
        double price;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessionCust = (Customer)Session["CustOBJ"];
           
            if (sessionCust != null)
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    int customerID = sessionCust.CustomerID;
                    cart = new Cart(customerID, 1);

                    SqlCommand sqlCommand;

                    sqlCommand = new SqlCommand("SELECT ProductID, Quantity FROM [ShoppingCart] WHERE CustomerID = @CustomerID", sqlConnection);// WHERE OrderID = " + Session["ID"].ToString(), sqlConnection);

                    sqlCommand.Parameters.Add("@CustomerID", SqlDbType.Int);
                    sqlCommand.Parameters["@CustomerID"].Value = sessionCust.CustomerID;

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
                double cartTotal = 0.0;
                ICart cartWithCase = new WithCase(cart);
                ICart cartWithAccessory = new WithAccessory(cart);

                if (cart.checkWithCase(sessionCust.CustomerID) && cart.checkWithAccessory(sessionCust.CustomerID))
                {
                    ICart cartWithAccessoryAndCase = new WithAccessory(cartWithCase);
                    cartTotal = cartWithAccessoryAndCase.getTotal(sessionCust.CustomerID);
                }
                else if (cart.checkWithCase(sessionCust.CustomerID) && !cart.checkWithAccessory(sessionCust.CustomerID))
                {
                    cartTotal = cartWithCase.getTotal(sessionCust.CustomerID);
                }
                else if (!cart.checkWithCase(sessionCust.CustomerID) && cart.checkWithAccessory(sessionCust.CustomerID))
                {
                    cartTotal = cartWithAccessory.getTotal(sessionCust.CustomerID);
                }
                else if (!cart.checkWithCase(sessionCust.CustomerID) && !cart.checkWithAccessory(sessionCust.CustomerID))
                {
                    cartTotal = cart.getTotal(sessionCust.CustomerID);
                }

                lblTotal.Text = "Total cost of items in cart: €" + Convert.ToString(cartTotal);
            }
            else
                Response.Write("Error: no customer in session, please log in.");
        }

        protected void EmptyCart_Click(object sender, EventArgs e)
        {

            sessionCust = (Customer)Session["CustOBJ"];
            if (sessionCust != null)
            {
                cart = new Cart(sessionCust.CustomerID, 1);

                cart.emptyCart(sessionCust.CustomerID);
                //refresh the page
                Response.Redirect(Request.RawUrl.ToString()); 
            }

        }
    }
}