using System;
namespace LibraryManagementApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Main Method");
            Operations.AddDefaultData();
            Operations.Mainmenu();
        }

    }

}