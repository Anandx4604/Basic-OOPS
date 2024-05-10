using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment
{ public enum Gender{Select,Male,Female,Transgender}
    public class UserDetails
    {
        private static int s_registrationID = 1001;
        public string RegistrationID{get;}
        public string UserName{get;set;}
        public int Age{get;set;}
        public Gender Gender{get;set;}
        public string Qualification{get;set;}
        public long MobileNumber{get;set;}
        public string MailID{get;set;}
        public UserDetails(string userName,int age,Gender gender,string qualification,long mobileNumber,string mailID )
        {
            s_registrationID++;
            RegistrationID = "SYNC"+s_registrationID;
            UserName = userName;
            Age = age;
            Gender = gender;
            Qualification = qualification;
            MobileNumber = mobileNumber;
            MailID = mailID;
        }
    }
}