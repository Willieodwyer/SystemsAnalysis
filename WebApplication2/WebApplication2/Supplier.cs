using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int PhoneNum { get; set; }
        public String Notes { get; set; }

        public Supplier(int supplierID, String name, String address, int phoneNum, String notes)
        {
            SupplierID = supplierID;
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
        }
    }
}