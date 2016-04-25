using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int PhoneNum { get; set; }
        public String Notes { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public CustomerMapper CustomerMapper { get; set; }

        private static Customer instance = null;
            
        public static Customer getInstance(int customerID, String name, String address, int phoneNum, 
            String notes, String username,String password){
                if (instance == null)
                {
                    instance = new Customer(customerID, name, address, phoneNum, notes, username, password);
                }
                return instance;
        }

        protected Customer(int customerID, String name, String address, int phoneNum, String notes, String username,
                        String password)
        {
            CustomerMapper.getCustomerID(this);
            CustomerID = customerID;
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
            Username = username;
            Password = password;
        }

        public string AddCustomer()
        {
            return CustomerMapper.AddCustomer(this);
        }
        public string EditCustomer(int customerID, String name, String address, int phoneNum, String notes, String username,
                        String password)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            PhoneNum = phoneNum;
            Notes = notes;
            Username = username;
            Password = password;
            return CustomerMapper.EditCustomer(this);
        }

        public string DeleteCustomer()
        {
            return CustomerMapper.DeleteCustomer(this);
        }

    
    }
}