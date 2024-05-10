using System;
namespace EcommerceApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Main Method");
            FileHandling.Create();
            Operation.AddDefaultData();
            Operation.Mainmenu();
        }

    }

}