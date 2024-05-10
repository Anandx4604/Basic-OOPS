using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LibraryManagementApplication
{
    public enum Gender { Select, Male, Female, Transgender };
    public enum Department{Select,ECE,EEE,CSE}
    public class UserDetails
    {
        //fields
        private static int s_userID = 3000;
        //properties
        public string UserID { get; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public long MobileNumber { get; set; }
        public string EmailID { get; set; }
        public double WalletBalance { get; set; }

        public UserDetails(string userName, Gender gender, Department department, long mobileNumber, string emailID, double walletBalance)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            EmailID = emailID;
            WalletBalance = walletBalance;

        }
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }
        public bool IsDeductBalance(double amount)
        {
            if (WalletBalance < amount )
            {
                return false;
            }
            else
            {
                WalletBalance -= amount;
                return true;
            }

        }

    }
}