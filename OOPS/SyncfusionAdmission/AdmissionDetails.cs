using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public enum AdmissionStatus{Select,Admitted,Cancelled}

    public class AdmissionDetails
    {
        private static int s_admissionID = 1000;
        //properties

        public string AdmissionID {get;}
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            s_admissionID++;
            AdmissionID = "ADID" + s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

        public AdmissionDetails(string admission)
        {
            string[] values = admission.Split(",");
            s_admissionID = int.Parse(values[0].Remove(0, 4));
            AdmissionID = values[0];
            StudentID = values[1];
            DepartmentID = values[2];
            AdmissionDate = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            AdmissionStatus = Enum.Parse<AdmissionStatus>(values[4]);
        }
        

    }
}