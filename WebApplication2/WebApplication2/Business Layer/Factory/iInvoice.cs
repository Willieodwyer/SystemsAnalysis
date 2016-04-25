using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneRetailer.DataLayer;

namespace MobilePhoneRetailer.BusinessLayer.Factory
{
    public interface iInvoice
    {
        void print();

        void setPrice();
        int getPrice();

        void setCustID();
        int getCustID();

        void setProductID();
        int getProductID();

        void setAddress();
        string getAddress();
    }
}
