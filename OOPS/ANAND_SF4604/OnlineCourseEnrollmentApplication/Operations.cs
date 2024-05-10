using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollmentApplication
{
    public static class Operations
    {
        static List<UserDetails> userDetailsList = new List<UserDetails>();
        static List<CourseDetails> courseDetailsList = new List<CourseDetails>();
        static List<EnrollmentDetails> enrollmentDetailsList = new List<EnrollmentDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultValues()
        {
            System.Console.WriteLine("Adding Default Values...");
            System.Console.WriteLine("\nAdding User Default Values...");
            UserDetails user1 = new UserDetails("Ravichandran", 30, Gender.Male, "ME", 9938388333, "ravi@gmail.com");
            UserDetails user2 = new UserDetails("Priyadharshini", 25, Gender.Female, "BE", 9944444455, "priya@gmail.com");
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);
            foreach (UserDetails user in userDetailsList)
            {
                System.Console.WriteLine($"| {user.RegistrationID,-5} | {user.UserName,-15} | {user.Age,-5} | {user.Gender,-10} | {user.Qualification,-5} | {user.MobileNumber,-10} | {user.MailID,-15}");
            }

            System.Console.WriteLine("\nAdding default Course details...");
            CourseDetails course1 = new CourseDetails("C#", "Baskaran", 5, 0);
            CourseDetails course2 = new CourseDetails("HTML", "Ravi", 2, 5);
            CourseDetails course3 = new CourseDetails("CSS", "Priyadharshini", 2, 3);
            CourseDetails course4 = new CourseDetails("JS", "Baskaran", 3, 1);
            CourseDetails course5 = new CourseDetails("TS", "Ravi", 1, 2);
            courseDetailsList.Add(course1);
            courseDetailsList.Add(course2);
            courseDetailsList.Add(course3);
            courseDetailsList.Add(course4);
            courseDetailsList.Add(course5);

            foreach (CourseDetails course in courseDetailsList)
            {
                System.Console.WriteLine($"| {course.CourseID,-5} | {course.CourseName,-10}  |  {course.TrainerName,-15} |  {course.CourseDuration,-5} | {course.SeatsAvailable,-5}");
            }

            System.Console.WriteLine("\nAdding default Enrollment details...");
            EnrollmentDetails enrollment1 = new EnrollmentDetails("CS2001", "SYNC1001", new DateTime(2024, 01, 28));
            EnrollmentDetails enrollment2 = new EnrollmentDetails("CS2003", "SYNC1001", new DateTime(2024, 02, 15));
            EnrollmentDetails enrollment3 = new EnrollmentDetails("CS2004", "SYNC1002", new DateTime(2024, 02, 18));
            EnrollmentDetails enrollment4 = new EnrollmentDetails("CS2002", "SYNC1002", new DateTime(2024, 02, 20));
            enrollmentDetailsList.Add(enrollment1);
            enrollmentDetailsList.Add(enrollment2);
            enrollmentDetailsList.Add(enrollment3);
            enrollmentDetailsList.Add(enrollment4);
            foreach (EnrollmentDetails enroll in enrollmentDetailsList)
            {
                System.Console.WriteLine($"| {enroll.EnrollmentID,-5} | {enroll.CourseID,-5} | {enroll.RegistrationID,-5} | {enroll.EnrollmentDate,-15:dd/MM/yyyy}");
            }
        }

        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\nMain Menu");
                System.Console.WriteLine("\n1.User Registration \n2.User Login \n3.Exit");
                System.Console.Write("Select an option(1/2/3):");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }

                    case 2:
                        {
                            UserLogin();
                            break;
                        }

                    case 3:
                        {
                            flag = false;
                            System.Console.WriteLine("Exiting the appllication...");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid option!");
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegistration()
        {
            System.Console.WriteLine("----- User registration ------");
            System.Console.Write("Enter your Name:");
            string userName = Console.ReadLine();
            System.Console.Write("Enter your Age:");
            int age = int.Parse(Console.ReadLine());
            System.Console.Write("Enter your gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter your Qualification:");
            string qualification = Console.ReadLine().ToUpper(); ;
            System.Console.Write("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.Write("Enter your MailID:");
            string mailID = Console.ReadLine();

            UserDetails newUser = new UserDetails(userName, age, gender, qualification, mobileNumber, mailID);
            userDetailsList.Add(newUser);
            System.Console.WriteLine($"Registration Successful! Your UserID:{newUser.RegistrationID}");
        }

        public static void UserLogin()
        {
            bool flag = true;
            System.Console.WriteLine("----- User Login -----");
            System.Console.Write("Enter your UserID:");
            string registrationID = Console.ReadLine().ToUpper(); ;
            foreach (UserDetails user in userDetailsList)
            {
                if (registrationID == user.RegistrationID)
                {
                    flag = false;
                    System.Console.WriteLine("Login Successful!");
                    currentLoginUser = user;
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid UserID! Please enter a valid one");
            }
        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("----- Sub Menu -----");
                System.Console.WriteLine("\n1.Enroll Course \n2.View Enrollment History \n3.Next Enrollment \n4.Exit");
                System.Console.Write("Select an option(1/2/3/4):");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            EnrollCourse();
                            break;
                        }

                    case 2:
                        {
                            ViewEnrollmentHistory();
                            break;
                        }

                    case 3:
                        {
                            NextEnrollment();
                            break;
                        }

                    case 4:
                        {
                            System.Console.WriteLine("Exiting Sub Menu....");
                            flag = false;
                            MainMenu();
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Inavlid Option!");
                            break;
                        }
                }
            } while (flag);
        }
        public static void EnrollCourse()
        {
            System.Console.WriteLine("----- Enroll Course ----");
            System.Console.WriteLine("Course Details:");
            bool flag = true;
            bool newEnrollment = true;
            foreach (CourseDetails course in courseDetailsList)
            {
                System.Console.WriteLine($"| {course.CourseID,-5} | {course.CourseName,-10}  |  {course.TrainerName,-15} |  {course.CourseDuration,-5} | {course.SeatsAvailable,-5}");
            }


            // 2.Then Ask the user to pick one course by Asking “Enter Course ID to enroll”.
            System.Console.Write("Enter Course ID to enroll:");
            string courseID = Console.ReadLine().ToUpper();
            // 3.	Check for the seat availability for the course selected. 
            // If there is no seat available, display as “Seats are not available for the current course” 
            // and show the sub menu. 
            foreach (CourseDetails course in courseDetailsList)
            {
                if (courseID == course.CourseID)
                {
                    flag = false;
                    if (course.SeatsAvailable != 0)
                    {
                        int courseCount = 0;
                        foreach (EnrollmentDetails enroll in enrollmentDetailsList)
                        {
                            if (currentLoginUser.RegistrationID == enroll.RegistrationID)
                            {
                                courseCount++;
                            }
                        }
                        DateTime endingCourseDate = DateTime.MaxValue;
                        foreach (EnrollmentDetails enroll3 in enrollmentDetailsList)
                        {
                            if (currentLoginUser.RegistrationID == enroll3.RegistrationID)
                            {
                                if (endingCourseDate > enroll3.EnrollmentDate)
                                {
                                    endingCourseDate = enroll3.EnrollmentDate;
                                }
                            }
                        }

                        // 4.	If the seat is available for enrollment, 
                        // need to check whether the user already enrolled for any courses. 
                        // Because user can enroll for 2 courses maximum at a time.

                        foreach (EnrollmentDetails enroll1 in enrollmentDetailsList)
                        {
                            if (currentLoginUser.RegistrationID == enroll1.RegistrationID)
                            {
                                newEnrollment = false;
                                if (courseCount < 2)
                                {

                                    enroll1.EnrollmentDate = DateTime.Today;
                                    System.Console.WriteLine("Enrolled on course!");
                                    EnrollmentDetails newEnroll = new EnrollmentDetails(course.CourseID, currentLoginUser.RegistrationID, DateTime.Today);
                                    enrollmentDetailsList.Add(newEnroll);
                                    System.Console.WriteLine($"user enrolled {course.CourseName} on {newEnroll.EnrollmentDate:dd/MM/yyyy}  and its course duration is {course.CourseDuration} days.");
                                    break;
                                }

                                else if (courseCount >= 2)
                                {
                                    System.Console.WriteLine($"You have already enrolled two courses. You can enroll next course on {endingCourseDate.AddDays(course.CourseDuration):dd/MM/yyyy}");
                                    break;

                                }

                            }
                            if (newEnrollment)
                            {
                                System.Console.WriteLine("Enrollment Succesful!");
                                EnrollmentDetails newEnroll = new EnrollmentDetails(course.CourseID, currentLoginUser.RegistrationID, DateTime.Today);
                                enrollmentDetailsList.Add(newEnroll);
                                System.Console.WriteLine($"user enrolled {course.CourseName} on {newEnroll.EnrollmentDate:dd/MM/yyyy}  and its course duration is {course.CourseDuration} days.");
                                break;

                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Seats are not available for the current course");
                        SubMenu();
                    }
                }
            }

            if (flag)
            {
                System.Console.WriteLine("Invalid Course ID!");
            }
        }
        public static void ViewEnrollmentHistory()
        {
            bool flag = true;
            System.Console.WriteLine("---- Enrollment History ----");
            foreach (EnrollmentDetails enroll in enrollmentDetailsList)
            {
                if (currentLoginUser.RegistrationID == enroll.RegistrationID)
                {
                    flag = false;
                    System.Console.WriteLine($"| {enroll.EnrollmentID,-5} | {enroll.CourseID,-5} | {enroll.RegistrationID,-5} | {enroll.EnrollmentDate,-15:dd/MM/yyyy}");
                }
            }
            if(flag)
            {
                System.Console.WriteLine("No Enrollment History Found!");
            }

        }
        public static void NextEnrollment()
        {
            System.Console.WriteLine("----- Next Enrollment -----");
            bool flag = true;
            DateTime endingCourseDate = DateTime.MaxValue;
            foreach (EnrollmentDetails enroll3 in enrollmentDetailsList)
            {
                if (currentLoginUser.RegistrationID == enroll3.RegistrationID)
                {
                    if (endingCourseDate > enroll3.EnrollmentDate)
                    {
                        endingCourseDate = enroll3.EnrollmentDate;
                    }
                }
            }


            foreach (EnrollmentDetails enroll4 in enrollmentDetailsList)
            {
                foreach (CourseDetails course in courseDetailsList)
                {

                    if (currentLoginUser.RegistrationID == enroll4.RegistrationID)
                    {
                        flag = false;
                        if (enroll4.CourseID == course.CourseID)
                        {
                            System.Console.WriteLine($"You can enroll next course on {endingCourseDate.AddDays(course.CourseDuration):dd/MM/yyyy}");
                            break;
                        }
                    }
                }
                // break;
            }

            if(flag)
            {
                System.Console.WriteLine("You haven't Enrolled in any courses yet!");
            }
        }
    }
}