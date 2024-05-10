using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyncfusionAdmission
{
    public enum Gender { Select, Male, Female, Transgender }
    public class StudentDetails
    {
        //fields 
        private static int s_studentID = 3000;

        //properties
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Maths { get; set; }


        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, double physics, double chemistry, double maths)
        {
            s_studentID++;
            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Physics = physics;
            Maths = maths;

        }

        public StudentDetails(string student)
        {
            string[] values = student.Split(",");
            StudentID = values[0];
            s_studentID = int.Parse(values[0].Remove(0,2)); //remove SF and increment Student ID
            StudentName = values[1];
            FatherName = values[2];
            DOB = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(values[4]);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        }

        public double Average()
        {
            double average = (double)(Physics + Chemistry + Maths) / 3.0;
            return average;
        }

        public bool IsEligible(double cutOff)
        {
            if (Average() >= cutOff)
            {
                return true;
            }

            else
            {
                return false;
            }
        }


    }

}