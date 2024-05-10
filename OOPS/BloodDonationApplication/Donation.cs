using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationApplication
{
    public enum BloodGroup { A_Positive, B_Positive, O_Positive, AB_Positive }
    public class Donation
    {
        //fields
        private static int s_donationID = 1000;
        //properties
        public string DonationID { get;}
        public string DonorID { get; }
        public DateTime DonationDate { get; set; }
        public double Weight { get; set; }
        public double BloodPressure { get; set; }
        public double HemoglobinCount { get; set; }
        public BloodGroup BloodGroup { get; set; }


        //Constrcutor
        public Donation(string donorID, DateTime donationDate,double weight, double bloodpressure, double hemoglobinCount,BloodGroup bloodGroup)
        {
            s_donationID++;
            DonationID = "DID" + s_donationID;
            DonorID = donorID;
            DonationDate = donationDate;
            Weight = weight;
            BloodPressure = bloodpressure;
            HemoglobinCount = hemoglobinCount;
            BloodGroup = bloodGroup;

        }

    }
}