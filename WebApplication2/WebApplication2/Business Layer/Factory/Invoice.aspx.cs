using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication2.Business_Layer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oID = OrderDropDownList.SelectedValue;
            int orderID = Convert.ToInt32(oID);

            string category = RadioButtonList1.SelectedValue;
            iInvoice inv = InvoiceFactory.getInvoice(orderID, category);
            inv.setPrice();
            inv.setCustID();
            inv.setProductID();
            inv.setAddress();
            inv.print();
        }
    }
}
