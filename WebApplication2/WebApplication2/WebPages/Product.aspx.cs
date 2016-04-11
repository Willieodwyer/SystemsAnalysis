using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = PriceBox.Text;
            int pr = Convert.ToInt32(s);
            float price = (float)pr;
            p = new Product(ManufacturerBox.Text,NameBox.Text,price);
            p.addProduct();
            
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string type = TypeDropDown.SelectedValue;
            string s = EditPrice.Text;
            int pr = Convert.ToInt32(s);
            float price = (float)pr;
            Product temp = new Product(type,"",0);
            ProductMapper.editProductDB(type, EditManufacturer.Text, EditName.Text, price);
        }

    }
}
