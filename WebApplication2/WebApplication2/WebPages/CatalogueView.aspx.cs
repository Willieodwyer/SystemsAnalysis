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
using MobilePhoneRetailer.BusinessLayer;
using MobilePhoneRetailer.BusinessLayer.Cart;

namespace MobilePhoneRetailer.WebPages
{
    public partial class CatalogueView : System.Web.UI.Page
    {
        static Catalogue catalogue = new Catalogue();
        static Cart sessionCart;
        static Customer sessionCust;

        public Catalogue Catalogue
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
            sessionCust = (Customer)Session["CustOBJ"];
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (sessionCust != null)
            {
                sessionCart = new Cart(sessionCust.CustomerID, 1);
                //Get the button clicked.
                Button btnAddToCart = ((Button)e.CommandSource);
                //get the row the button lives in
                GridViewRow currentRow = ((GridViewRow)btnAddToCart.NamingContainer);
                //find the quantity text box
                TextBox txtQuantity = ((TextBox)currentRow.FindControl("txtQuantity"));
                Int32 qty = Convert.ToInt32(txtQuantity.Text);
                //get the row's datakey value by keyname using .Values["keyname"] or if you only have one datakey field you can just use .Value  
                Int32 prodId = Convert.ToInt32(GridView3.DataKeys[currentRow.RowIndex].Values["ProductID"].ToString());
                //pass the quantity value and the prodid to your AddToCart method. 
                //CartFunctions.AddItemToCart(prodId, txtQuantity.Text, 0.0M);

                sessionCart.AddToCart(prodId, qty);
                //Response.Write for testing only.. 
                lblAddToCart.Text = txtQuantity.Text + " of ProductID " + prodId + " added to cart.";
            }
            else
                Response.Write("Error: no customer is in session.");
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoice.aspx", true);
        }
    }

}
