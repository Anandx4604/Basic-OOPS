using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlineCourseEnrollmentApplication
{
    public class EnrollmentDetails
    {
        private static int s_enrollmentID = 3000;
        public string EnrollmentID { get; set; }
        public string CourseID { get; }
        public string RegistrationID { get; }
        public DateTime EnrollmentDate { get; set; }

        public EnrollmentDetails(string courseID, string registrationID,DateTime enrollmentDate)
        {
            s_enrollmentID++;
            EnrollmentID = "EMT" + s_enrollmentID;
            CourseID = courseID;
            RegistrationID = registrationID;
            EnrollmentDate = enrollmentDate;
        }

    }
}