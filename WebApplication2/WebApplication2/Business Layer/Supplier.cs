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
    public class Supplier
    {
        public int SupplierID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public double PhoneNum { get; set; }
        public String Notes { get; set; }

        public SupplierMapper SupplierMapper
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Supplier(String name, String address, double phoneNum, String notes)
        {
            SupplierMapper.GetSupplierID(this);
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
        }

        public string Add()
        {
            return SupplierMapper.Add(this);
        }

        public static string Delete(int suppID)
        {
            return SupplierMapper.Delete(suppID);
        }

        public string Edit(int suppiD, String name, String address, int phoneNum, String notes)
        {
            return SupplierMapper.Edit(this, suppiD, name, address, phoneNum, notes);
        }
    }
}
