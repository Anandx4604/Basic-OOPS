using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication
{
    public class ProductDetails
    {
        //fields
        private static int s_productID = 2000;
        //properties
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails(string productName, int stock, double price, int shippingDuration)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }
    }
}