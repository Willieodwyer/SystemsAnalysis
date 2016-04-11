using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Stock newStock = new Stock(2, 100);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList.SelectedValue);
            int Quantity = Convert.ToInt32(QuantityBox.Text);
            Stock newStock = new Stock(id,Quantity);
            newStock.addStock(id, Quantity);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList.SelectedValue);
            int Quantity = Convert.ToInt32(QuantityBox.Text);
            Stock newStock = new Stock(id, Quantity);
            newStock.updateStock(id, Quantity);
        }

        
    }
}
