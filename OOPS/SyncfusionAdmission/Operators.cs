using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public static class Operators
    {
        public static List<StudentDetails> studentlist = new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        static StudentDetails currentLoginStudent;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Default Data...");
            // create List for all classes
            // create objects
            // add to list
            // Traverse and show added data

            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethu", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);

            studentlist.Add(student1);
            studentlist.Add(student2);

            DepartmentDetails dept1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails dept2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails dept3 = new DepartmentDetails("MECH", 29);
            DepartmentDetails dept4 = new DepartmentDetails("ECE", 29);

            departmentList.Add(dept1);
            departmentList.Add(dept2);
            departmentList.Add(dept3);
            departmentList.Add(dept4);

            AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 11, 05), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 11, 05), AdmissionStatus.Admitted);

            admissionList.Add(admission1);
            admissionList.Add(admission2);

            Console.WriteLine("\n----Adding Student Default Data----");
            foreach (StudentDetails student in studentlist)
            {
                System.Console.WriteLine($"|  {student.StudentID,-5} | {student.StudentName,-15} | {student.FatherName,-15}  |   {student.DOB.ToString("dd/MM/yyyy"),-10}  |  {student.Gender,-10}  |  {student.Physics,-5}  | {student.Chemistry,-5}  | {student.Maths,-5}  |");
            }

            Console.WriteLine("\n----Adding Department Default Data----");
            foreach (DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|  {department.DepartmentID,-5}  |  {department.DepartmentName,-5} |  {department.NumberOfSeats,-5}  |");
            }

            Console.WriteLine("\n----Adding Admission Default Data----");
            foreach (AdmissionDetails admit in admissionList)
            {
                System.Console.WriteLine($"|  {admit.AdmissionID}  |  {admit.StudentID}  | {admit.DepartmentID}  |  {admit.AdmissionDate}  |  {admit.AdmissionStatus}  |");
            }


        }

        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n Welcome to Syncfusion College of Engineering and Technology");
                Console.WriteLine("----Student Admission----");
                System.Console.WriteLine("1.Student Registration  2.Student Login  3.Exit");
                System.Console.Write("Select an option (1/2/3):");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }

                    case 2:
                        {
                            Login();
                            break;
                        }

                    case 3:
                        {
                            System.Console.WriteLine("Exit selected!");
                            flag = false;
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid Option! Enter correct option 1/2/3/4");
                            break;
                        }
                }

            } while (flag);


        }

        public static void Registration()
        {
            System.Console.WriteLine("Student Registration");
            System.Console.Write("Enter Student Name:");
            string studentName = Console.ReadLine();

            System.Console.Write("Enter Father Name:");
            string fatherName = Console.ReadLine();

            System.Console.Write("Enter Date of Birth(dd/MM/yyyy):");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            System.Console.Write("Enter Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter Physics Marks:");
            double physics = double.Parse(Console.ReadLine());

            System.Console.Write("Enter Chemistry Marks:");
            double chemistry = double.Parse(Console.ReadLine());

            System.Console.Write("Enter Maths Marks:");
            double maths = double.Parse(Console.ReadLine());

            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physics, chemistry, maths);
            studentlist.Add(student);
            System.Console.WriteLine($"\nStudent Registration Successful! Your student LoginID:{student.StudentID}");

        }

        public static void Login()
        {
            Console.WriteLine("\nStudent Login");
            //get userID
            //traverse student list
            //find user id  is present
            //if user id not present show invalid user id
            //if user id is present store current login cookie object   globally
            //Then show submenu

            System.Console.Write("Enter Student LoginID:");
            string loginID = Console.ReadLine().ToUpper();

            bool flag = true;
            foreach (StudentDetails student in studentlist)
            {
                if (loginID == student.StudentID)
                {
                    System.Console.WriteLine("Login Successful!");
                    flag = false;
                    currentLoginStudent = student;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                System.Console.WriteLine("Invalid LoginID!");
            }

        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n---Submenu---");
                System.Console.WriteLine("1.Check Eligibility 2.Show Details 3.Take Admission 4.Cancel Admission 5.Show Admission Details 6.Exit");
                System.Console.Write("Select an option (1/2/3/4/5/6):");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Eligibility();
                            break;
                        }

                    case 2:
                        {
                            ShowDetails();
                            break;
                        }

                    case 3:
                        {
                            System.Console.WriteLine("take admission");
                            takeAdmission();
                            break;
                        }

                    case 4:
                        {
                            System.Console.WriteLine("Cancel Admission");
                            CancelAdmission();
                            break;
                        }

                    case 5:
                        {
                            System.Console.WriteLine("Show Admission Details");
                            ShowAdmissionDetails();
                            break;
                        }

                    case 6:
                        {
                            System.Console.WriteLine("Exiting Sub Menu...");
                            flag = false;
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid Option!");
                            break;
                        }
                }

            } while (flag);
        }

        public static void Eligibility()
        {
            bool result = currentLoginStudent.IsEligible(75.0);
            System.Console.WriteLine(result ? "Student is Eligible for admission" : "Student is Not Eligible for admission");
        }
        public static void ShowDetails()
        {
            System.Console.WriteLine($"Student ID:{currentLoginStudent.StudentID,-5} ||  Student Name:{currentLoginStudent.StudentName,-15} || Father Name:{currentLoginStudent.FatherName,-15} Date of Birth:{currentLoginStudent.DOB}|| Gender:{currentLoginStudent.Gender,-10}  || Physics:{currentLoginStudent.Physics} || Chemistry: {currentLoginStudent.Chemistry} || Physics:{currentLoginStudent.Physics}||");
        }
        public static void ShowAdmissionDetails()
        {
            bool flag = true;
            foreach (AdmissionDetails admit in admissionList)
            {
                if (currentLoginStudent.StudentID == admit.StudentID)
                {
                    System.Console.WriteLine($"|  {admit.AdmissionID}  |  {admit.StudentID}  | {admit.DepartmentID}  |  {admit.AdmissionDate}  |  {admit.AdmissionStatus}  |");
                    flag = false;
                }

            }
            if (flag)
            {
                System.Console.WriteLine("Student didnt take admission");
            }
        }

        public static void takeAdmission()
        {

            //Show the list of available departments and number of seats available by traversing the department details list
            foreach (DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|  {department.DepartmentID,-5}  |  {department.DepartmentName,-5} |  {department.NumberOfSeats,-5}  |");
            }
            //Ask the student to pick one DepartmentID.

            System.Console.Write("Enter one DepartmentID:");
            string departmentID = Console.ReadLine().ToUpper();

            //Validate the DepartmentID is present in the list. 
            bool flag = true;
            foreach (DepartmentDetails department in departmentList)
            {
                // If it is present, then check whether he is eligible to take admission.
                if (departmentID == department.DepartmentID)
                {
                    flag = false;
                    bool temp = currentLoginStudent.IsEligible(75.0);
                    if (temp)
                    {
                        System.Console.WriteLine("Student is Eligible for admission");
                        //If he is eligible, check whether seat available or not, 
                        if (department.NumberOfSeats > 0)
                        {
                            System.Console.WriteLine("Seats available");
                            // if seats available then Check whether the student has already taken any admission by traversing admission details list. If he didn’t took any admission previously.
                            bool admissionStatusFlag = true;
                            foreach (AdmissionDetails admit in admissionList)
                            {
                                if (currentLoginStudent.StudentID == admit.AdmissionID && admit.AdmissionStatus == AdmissionStatus.Admitted)
                                {
                                    admissionStatusFlag = false;
                                }
                            }
                            //Then, Reduce the seat count in department list and create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked and add it to list.
                            if (admissionStatusFlag)
                            {
                                department.NumberOfSeats--;
                                AdmissionDetails admission = new AdmissionDetails(currentLoginStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                admissionList.Add(admission);
                                //Finally show “Admission took successfully. Your admission ID – SF3001”. 
                                System.Console.WriteLine($"Admission took successfully. Your admission ID -{admission.AdmissionID}");
                            }

                            else
                            {
                                System.Console.WriteLine("You have already taken admission!");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("No seats available!");
                        }


                    }
                    else
                    {
                        System.Console.WriteLine("Student is not Eligible for admission");
                    }

                }

            }
            if (flag)
            {
                System.Console.WriteLine("Invalid DepartmentID");
            }

        }
        public static void CancelAdmission()
        {
            bool flag = true;
            // Show the current logged in student’s admission detail by traversing the list which AdmissionStatus Property is Booked. If found then show it.
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoginStudent.StudentID == admission.AdmissionID && admission.AdmissionStatus == AdmissionStatus.Admitted)
                {
                    flag = false;
                    // Change the Admission status property to Cancelled.
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;

                    // Return the seat to Department Details list
                    foreach (DepartmentDetails department in departmentList)
                    {
                        if (department.DepartmentID == admission.DepartmentID)
                        {
                            department.NumberOfSeats++;
                        }
                    }
                    // Finally show admission cancelled successfully.
                    System.Console.WriteLine("Admission cancelled successfully.");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not admitted yet!");
            }
        }
    }
}