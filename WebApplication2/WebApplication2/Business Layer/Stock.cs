using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Stock
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public StockMapper StockMapper
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Stock(int productID, int quantity)
        {
            ProductID = productID;
            Quantity = quantity;
        }

        public void addStock(int ProductID, int Quantity)
        {
            StockMapper.addStockDB(ProductID, Quantity);
        }

        public void updateStock(int ProductID,int Quantity)
        {
            StockMapper.updateStockBD(ProductID, Quantity);
        }
    }
}
