using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Cart
    {
        public int CustomerID { get; set; }
        public int CartID { get; set; }


        public Cart(int customerID, int cartID)
        {
            CartMapper.getCartID(this);
            CustomerID = customerID;
            CartID = cartID;
        }

        public string CreateCart()
        {
            return CartMapper.CreateCart(this);
        }


        public string EditCart(int customerID, int cartID)
        {
            CustomerID = customerID;
            CartID = cartID;
            return CartMapper.EditCart(this);
        }

        public string AddToCart(int productID, int quantity)
        {
            return CartMapper.AddToCart(this, productID, quantity);
        }

        public string RemoveFromCart(int productID)
        {
            return CartMapper.RemoveFromCart(this, productID);
        }
    }
        
}