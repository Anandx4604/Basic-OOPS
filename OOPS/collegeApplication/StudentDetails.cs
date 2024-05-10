using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegeApplication
{
    
    public enum Gender {Select, Male, Female, Transgender}
    public class StudentDetails
    {
        //Field
        private static int s_studentID = 1000;
        //Properties

        //Normal property
        // public string StudentName
        // {
        //     get
        //     {
        //         return _studentName;                
        //     }
        //     set
        //     {
        //         _studentName = value;
        //     }
        // }

        //Auto Property

        public string StudentID { get;}//set is removed, to restrict users not to modify ID's
        public string StudentName{get;set;}
        public string FatherName{ get; set;}
        public  Gender Gender{ get; set; }
        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        public int Maths { get; set; }
        public int Chemistry { get; set; }
        public int Physics { get; set; }

        // constructor
        public StudentDetails()
        {
            StudentName="Enter your name";
            FatherName="Enter your Father name";
            Gender = Gender.Select;
        }

        //Parameterised Constructor
        public StudentDetails(string studentName,string fatherName, Gender gender, DateTime dob, long phone, int maths,int chemistry, int physics)
        {
            s_studentID++;
            StudentID+= "SF"+s_studentID;
            StudentName = studentName;
            FatherName =  fatherName;
            Gender = gender;
            DOB = dob;
            Maths = maths;
            Chemistry = chemistry;
            Physics = physics;

        }

        //Destuctor
        ~StudentDetails()
        {
            Console.WriteLine($"Destructor Called!");
        }


        //Methods
        public bool CheckEligibility(double cutoff)
        {
            double average = (double)(Maths+Chemistry+Physics)/3;

            if(average>=cutoff)
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