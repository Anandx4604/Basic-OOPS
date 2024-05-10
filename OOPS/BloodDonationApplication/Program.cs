using System;
using BloodDonationApplication;
namespace BloodDonation
{
    class Program
    {
        public static void Main(string[] args)
        {
            Operations.AddDefaultData();
            Operations.Mainmenu();
        }
    }


}