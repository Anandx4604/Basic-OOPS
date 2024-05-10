using System;
namespace SyncfusionAdmission
{
    class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            // Operators.AddDefaultData();
            FileHandling.ReadFromCSV();
            Operators.Mainmenu();
            FileHandling.WriteToCSV();
        }
    }


}