using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class OrderContext
    {
        public Order Order { get; set; }
        public int CustType { get; set; }
        public int CustomerID { get; set; }
        public Product ProductID { get; set; }
        public int SupplierID { get; set; }
        public String Address { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Order Order1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Order Order2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public OrderContext(int custType, int customerID, Product productID, int supplierID, String address, double amount,
            DateTime date)
        {
            CustType = custType;
            switch (custType)
            {
                case 1: Order = new StandardOrder(customerID, productID, supplierID, address, amount, date); break;
                case 2: Order = new SilverOrder(customerID, productID, supplierID, address, amount, date); break;
                case 3: Order = new GoldOrder(customerID, productID, supplierID, address, amount, date); break;                
                default: Order = new StandardOrder(customerID, productID, supplierID, address, amount, date); break;
            }
        }

        public void changeState(int custType){
            CustType = custType;

            switch (custType)
            {
                case 1: Order = new StandardOrder(CustomerID, ProductID, SupplierID, Address, Amount, Date); break;
                case 2: Order = new SilverOrder(CustomerID, ProductID, SupplierID, Address, Amount, Date); break;
                case 3: Order = new GoldOrder(CustomerID, ProductID, SupplierID, Address, Amount, Date); break;
                default: Order = new StandardOrder(CustomerID, ProductID, SupplierID, Address, Amount, Date); break;
            }

        }
    }
}