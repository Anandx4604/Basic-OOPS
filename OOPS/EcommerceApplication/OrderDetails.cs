using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication
{
    public enum OrderStatus{Default,Ordered,Cancelled}
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        //properties
        public string OrderID { get; set; }
        public string CustomerID { get;}
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerID,string productID, double totalPrice, DateTime purchaseDate, int quantity,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID= "OID" + s_orderID;
            CustomerID = customerID; 
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }
    }
}