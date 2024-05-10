using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDriveApplication
{
    public enum Gender { Select, Male, Female }
    public class Beneficiary
    {
        private static int registrationNumber = 1000;
        public string RegistrationNumber { get;}
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string City { get; set; }


        public Beneficiary(string name,int age,Gender gender,long mobileNumber, string city)
        {
            registrationNumber++;
            RegistrationNumber = "BID" + registrationNumber;
            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber = mobileNumber;
            City = city;
        }

    }
}