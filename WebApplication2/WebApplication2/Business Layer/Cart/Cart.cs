using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    //Concrete Component Class 
    public class Cart : ICart
    {
        public int CustomerID { get; set; }
        public int CartID { get; set; }

        public CartMapper CartMapper
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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


        public override double getTotal(int custID)
        {
            return CartMapper.getTotal(custID);
        }

        public string emptyCart(int custID)
        {
            return CartMapper.emptyCart(this, custID);
        }

        public Boolean checkWithCase(int custID)
        {
            return CartMapper.checkWithCase(this, custID);
        }

        public Boolean checkWithAccessory(int custID)
        {
            return CartMapper.checkWithAccessory(this, custID);
        }
    }

}
