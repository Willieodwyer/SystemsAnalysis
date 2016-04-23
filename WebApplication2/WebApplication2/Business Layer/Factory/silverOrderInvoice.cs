using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class silverOrderInvoice
    {
        public int orderID { get; set; }
        public int price;
        public int amount;
        public int custID;
        public int pID;
        public string address;
        public DateTime OrderDate;

        public silverOrderInvoice(int ID)
        {
            orderID = ID;
        }

        public static silverOrderInvoice createSilverInvoice(int ID)
        {
            return new silverOrderInvoice(ID);
        }

        public void setPrice()
        {
            price = Convert.ToInt32(OrderMapper.GetOrderPrice(orderID));
        }

        public int getPrice()
        {
            return price;
        }

        public int getCustID() //return attr
        {
            return custID;
        }

        public void setCustID() //set attr
        {
            custID = OrderMapper.GetOrderCustID(orderID);
        }

        public int getProductID() //return attr
        {
            return pID;
        }

        public void setProductID() //set attr
        {
            pID = OrderMapper.GetOrderProductID(orderID);
        }

        public string getAddress() //return attr
        {
            return address;
        }

        public void setAddress() //set attr
        {
            address = OrderMapper.GetOrderAddress(orderID);
        }

        public DateTime getDate() //return attr
        {
            return OrderDate;
        }

        public void setDate() //set attr
        {
            OrderDate = OrderMapper.GetOrderDate(orderID);
        }
    }
}