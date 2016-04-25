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


namespace MobilePhoneRetailer.BusinessLayer.Order
{
    public class StandardOrderDiscount : OrderDiscount
    {
        override public double disc { get; set; }

        public StandardOrderDiscount()
        {
            disc = 1;
        }

        override public void applyDiscount(Order ord)
        {
            ord.Amount = ord.Amount * disc;
        }
        
    }
}
