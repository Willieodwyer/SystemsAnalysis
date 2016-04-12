using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.WebPages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart cart = new Cart(1, 1);
            WithCase cartWithCase = new WithCase(cart);
            WithAccessory cartWithAccessory = new WithAccessory(cart);


            cart.AddToCart(1, 1);
            cart.AddToCart(2, 1);
            cart.AddToCart(3, 1);

            //Display total price
            lblTotal.Text = "Normal Price: " + Convert.ToString(cart.getTotal());
            //Display total price with Case discount 3%
            lblTotalWithCase.Text = "Price with Case decorator applied: " + Convert.ToString(cartWithCase.getTotal());
            //Display total price with Accessory discount 2%
            lblTotalWithAccessory.Text = "Price with Accessory decorator applied: " + Convert.ToString(cartWithAccessory.getTotal());

            //Display total price with Case and Accessory discount 5%
            //lblTotalWithDiscount.Text = "Price with Accessory and Case decorators applied: " + Convert.ToString(cartWithCaseAndAccessory.getTotal());
        }
    }
}