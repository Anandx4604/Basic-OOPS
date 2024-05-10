using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("SyncCart"))
            {
                System.Console.WriteLine("Creating Folder...");
                Directory.CreateDirectory("SyncCart");
            }

            if (!File.Exists("SyncCart/CustomerInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SyncCart/CustomerInfo.csv");
            }

            if (!File.Exists("SyncCart/ProductInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SyncCart/ProductInfo.csv");
            }

            if (!File.Exists("SyncCart/OrderInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SyncCart/OrderInfo.csv");
            }

            

        }
    }
}