using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment
{
    public class EnrollmentDetails
    {
        private static int s_enrollmentID = 3001;
        public string EnrollmentID{get;}
        public string CourseID{get;set;}
        public string RegistrationID{get;set;}
        public DateTime EnrollmentDate{get;set;}
        public EnrollmentDetails(string courseID,string registrationID,DateTime enrollmentDate)
        {
            s_enrollmentID++;
            EnrollmentID = "EMT"+s_enrollmentID;
            CourseID = courseID;
            RegistrationID = registrationID;
            EnrollmentDate = enrollmentDate;
        }
    }
}