using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Discount
    {
        public int customerClass { get; set; }
        public int productID { get; set; }

        public Discount(int custClass)
        {
            customerClass = custClass;
        }

        public double applyDiscount(double A, int pID)
        {
            double Amount = A; 
            switch (customerClass)
            {
                case 1:
                    Amount =  A * 0.8;
                    break;
                case 2:
                    Amount = A * .8;
                    break;

                case 3:
                    Amount = A * .7;
                    break;

                case 4:
                    Amount = A * .6;
                    break;
            }
            switch (pID)
            {
                case 1:
                    Amount = Amount * .95;
                    break;
                case 2:
                    Amount = Amount * .9;
                    break;

                case 3:
                    Amount = Amount * .85;
                    break;
            }
            return A;
        }
    }

}