using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Buffers;

namespace SyncfusionAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("SynfusionAdmission"))
            {
                System.Console.WriteLine("Creting Folder...");
                Directory.CreateDirectory("SynfusionAdmission");
            }

            //file for student info
            if (!File.Exists("SynfusionAdmission/StudentInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SynfusionAdmission/StudentInfo.csv").Close(); 
            }

            //file for Departmnent info
            if (!File.Exists("SynfusionAdmission/DepartmnentInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SynfusionAdmission/DepartmnentInfo.csv").Close(); 
            }

            //file for Admission info
            if (!File.Exists("SynfusionAdmission/AdmissionInfo.csv"))
            {
                System.Console.WriteLine("Creating File...");
                File.Create("SynfusionAdmission/AdmissionInfo.csv").Close(); 
            }
        }

        public static void WriteToCSV()
        {
            string[] students = new string[Operators.studentlist.Count];
            for (int i = 0; i < Operators.studentlist.Count; i++)
            {
                students[i] = Operators.studentlist[i].StudentID + "," + Operators.studentlist[i].StudentName + "," + Operators.studentlist[i].FatherName + "," + Operators.studentlist[i].DOB.ToString("dd/MM/yyyy") + "," + Operators.studentlist[i].Gender + "," + Operators.studentlist[i].Physics + "," + Operators.studentlist[i].Chemistry + "," + Operators.studentlist[i].Maths;
            }

            File.WriteAllLines("SynfusionAdmission/StudentInfo.csv", students);

            //Department info
            string[] departments = new string[Operators.departmentList.Count];
            for (int i = 0; i < Operators.departmentList.Count; i++)
            {
                departments[i] = Operators.departmentList[i].DepartmentID + "," + Operators.departmentList[i].DepartmentName + "," + Operators.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("SynfusionAdmission/DepartmnentInfo.csv", departments);

            //admisision info
            string[] admissions = new string[Operators.admissionList.Count];
            for (int i = 0; i < Operators.admissionList.Count; i++)
            {
                admissions[i] = Operators.admissionList[i].AdmissionID + "," + Operators.admissionList[i].StudentID + "," + Operators.admissionList[i].DepartmentID + "," + Operators.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy") + "," + Operators.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("SynfusionAdmission/AdmissionInfo.csv", admissions);
        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("SynfusionAdmission/StudentInfo.csv");
            foreach(string student in students)
            {
                StudentDetails newStudent = new StudentDetails(student);
                Operators.studentlist.Add(newStudent);
            }

            string[] departments = File.ReadAllLines("SynfusionAdmission/DepartmnentInfo.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operators.departmentList.Add(department1);
            }

            string[] admissions = File.ReadAllLines("SynfusionAdmission/AdmissionInfo.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operators.admissionList.Add(admission1);
            }
        
        }
    }
}