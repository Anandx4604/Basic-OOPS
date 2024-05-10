using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication
{
    public class UserRegistration
    {
        //fields 
        private static int s_donorID = 1000;

        //Properties
        public string DonorID { get; }
        public string DonorName { get; set; }
        public long MobileNumber { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int Age { get; set; }
        public DateTime LastDonationDate { get; set; }

        //Constructor
        public UserRegistration(string donorName,long mobileNumber, BloodGroup bloodGroup,int age,DateTime lastDonationDate)
        {
            s_donorID++;
            DonorID = "UID" + s_donorID;
            DonorName = donorName;
            MobileNumber = mobileNumber;
            BloodGroup = bloodGroup;
            Age = age;
            LastDonationDate = lastDonationDate;
        }
    }
}