using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
namespace collegeApplication;


class Program
    {
        public static void Main(string[] args)
        {

            //student1
            //Printout form for 1st person

            List<StudentDetails> studentList = new List<StudentDetails>();
            string option = "";
            do
            {
                Gender gender;
                //StudentDetails student1 = new StudentDetails();
                Console.WriteLine($"Student Registration Details:");

                System.Console.Write("Enter your name: ");
                string studentName = Console.ReadLine();

                System.Console.Write("Enter your father name:");
                string fatherName = Console.ReadLine();

                System.Console.Write("Enter your Gender:");
                bool temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

                while (!temp)
                {
                    Console.WriteLine($"Invalid Gender! Renter Gender Correctly!");
                    temp = Gender.TryParse(Console.ReadLine(), true, out gender);
                }


                System.Console.Write("Enter Date of birth (dd/MM/yyyy):");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                System.Console.Write("Enter your Phone Number:");
                long phone = long.Parse(Console.ReadLine());

                System.Console.Write("Enter your Maths marks:");
                int maths = int.Parse(Console.ReadLine());

                System.Console.Write("Enter your Chemistry marks:");
                int chemistry = int.Parse(Console.ReadLine());

                System.Console.Write("Enter your Physics marks:");
                int physics = int.Parse(Console.ReadLine());

                StudentDetails student = new StudentDetails(studentName, fatherName, gender, dob, phone, maths, chemistry, physics);
                Console.WriteLine($"You are Registered Succesfully! Your login ID:{student.StudentID}");
                studentList.Add(student);

                //Loop Breaker
                System.Console.WriteLine("Do you fill details for another student?:(yes/no)");
                option = Console.ReadLine();

            } while (option == "yes");

            Console.WriteLine($"Enter Student ID to Login");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;

            foreach (StudentDetails student in studentList)
            {
                if (student.StudentID == loginID)
                {
                    flag = false;
                    Console.WriteLine($"\nYour Name:{student.StudentName} \nYour Father name:{student.FatherName} \nGender:{student.Gender} \nDOB:{student.DOB.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Maths:{student.Maths} \nChemistry:{student.Chemistry} \nPhysics:{student.Physics}");

                    bool eligibility = student.CheckEligibility(75);
                    if (eligibility)
                    {
                        System.Console.WriteLine("You are eligilble for admission");
                    }

                    else
                    {
                        System.Console.WriteLine("You are not eligilble for admission");

                    }
                }
                if (flag)
                {
                    Console.WriteLine($"Invalid LoginID! Try again!");

                }

            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            System.Console.WriteLine("End Of Program");

        }
    }
