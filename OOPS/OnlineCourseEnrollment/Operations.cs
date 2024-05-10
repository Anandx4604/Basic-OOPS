using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment
{
    public static class Operations
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<CourseDetails> courseList = new List<CourseDetails>();
        static List<EnrollmentDetails> enrollmentList = new List<EnrollmentDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", 30, Gender.Male, "ME", 9938388333, "ravi@gmail.com");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Priyadharshini", 25, Gender.Female, "BE", 9944444455, "priya@gmail.com");
            userList.Add(user2);
            CourseDetails course1 = new CourseDetails("C#", "Baskaran", 5, 0);
            courseList.Add(course1);
            CourseDetails course2 = new CourseDetails("HTML", "Ravi", 2, 5);
            courseList.Add(course2);
            CourseDetails course3 = new CourseDetails("CSS", "Priyadharshini", 2, 3);
            courseList.Add(course3);
            CourseDetails course4 = new CourseDetails("JS", "Baskaran", 3, 1);
            courseList.Add(course4);
            CourseDetails course5 = new CourseDetails("TS", "Ravi", 1, 2);
            courseList.Add(course5);
            EnrollmentDetails enrollment1 = new EnrollmentDetails("CS2001", "SYNC1001", new DateTime(2024, 01, 28));
            enrollmentList.Add(enrollment1);
            EnrollmentDetails enrollment2 = new EnrollmentDetails("CS2003", "SYNC1001", new DateTime(2024, 02, 15));
            enrollmentList.Add(enrollment2);
            EnrollmentDetails enrollment3 = new EnrollmentDetails("CS2004", "SYNC1002", new DateTime(2024, 02, 18));
            enrollmentList.Add(enrollment3);
            EnrollmentDetails enrollment4 = new EnrollmentDetails("CS2002", "SYNC1002", new DateTime(2024, 02, 20));
            enrollmentList.Add(enrollment4);
            foreach (UserDetails user in userList)
            {
                System.Console.WriteLine($" | {user.UserName,-15} | {user.Age,-10} | {user.Gender,-15} | {user.Qualification,-10} | {user.MobileNumber,-15} | {user.MailID,-15}");
            }
            foreach (CourseDetails course in courseList)
            {
                System.Console.WriteLine($" | {course.CourseName,-10} | {course.TrainerName,-15} | {course.CourseDuration,-10} | {course.SeatsAvailable,-10} ");
            }
            foreach (EnrollmentDetails enrollment in enrollmentList)
            {
                System.Console.WriteLine($" | {enrollment.CourseID,-15} | {enrollment.RegistrationID,-10} | {enrollment.EnrollmentDate.ToString("dd/MM/yyyy"),-15}");
            }



        }
        public static void MainMenu()
        {
            System.Console.WriteLine("Online Course Enrollment");
            bool flag = true;
            System.Console.WriteLine("1.Registration\n 2.Login\n 3.Exit");
            int mainmenu = int.Parse(Console.ReadLine());
            do
            {
                switch (mainmenu)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Registration");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Login");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Exit");
                            flag = false;
                            break;
                        }

                }
            } while (flag);
        }
        public static void Registration()
        {
            System.Console.WriteLine("Enter your Name");
            string userName = Console.ReadLine();
            System.Console.WriteLine("Enter your Age");
            int age = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Gender Male Female Transgender");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.WriteLine("Enter your Qualification");
            string qualification = Console.ReadLine();
            System.Console.WriteLine("Enter your MobileNumber");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter your mailID");
            string mailID = Console.ReadLine();
            UserDetails user = new UserDetails(userName, age, gender, qualification, mobileNumber, mailID);
            userList.Add(user);
            System.Console.WriteLine($"User ID is{user.RegistrationID}");
            MainMenu();
        }
        public static void Login()
        {
            System.Console.WriteLine("Enter UserID");
            string registrationID = Console.ReadLine();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (registrationID == user.RegistrationID)
                {
                    System.Console.WriteLine("Login Successful");
                    flag = false;
                    currentLoginUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid RegistrationID. Please enter a valid one ");
            }
        }
        public static void SubMenu()
        {
            bool flag = false;
            System.Console.WriteLine("");
            do
            {
                System.Console.WriteLine("SubMenu");
                System.Console.WriteLine("1.Enroll Course\n 2.ViewEnrollmentHistory\n 3.NextEnrollment\n 4.Exit");
                int mainmenu = int.Parse(Console.ReadLine());
                switch (mainmenu)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Enroll Course");
                            EnrollCourse();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("View Enrollment History");
                            ViewEnrollmentHistory();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Next Enrollment");
                            NextEnrollment();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Enroll Course");
                            flag = true;
                            break;
                        }
                }
            } while (flag);
        }
        public static void EnrollCourse()
        { // 1.	Show the list of courses available by printing CourseID, CourseName, TrainerName, CourseDuration, SeatsAvailable.
            foreach (CourseDetails course in courseList)
            {
                System.Console.WriteLine($" | {course.CourseID,-10} | {course.CourseName,-10} | {course.TrainerName,-15} | {course.CourseDuration,-10} | {course.SeatsAvailable,-10} ");
            }
            // 2.	Then Ask the user to pick one course by Asking “Enter Course ID to enroll”.
            System.Console.WriteLine("Enter Course ID to enroll");
            string courseID = Console.ReadLine();
            int count = 0;
            bool flag = true;
            // 3.	Check for the seat availability for the course selected. 
            foreach (CourseDetails course in courseList)
            {
                if (courseID == course.CourseID)
                {
                    flag = false;
                    if (course.SeatsAvailable > 0)
                    { // 4.If the seat is available for enrollment, need to check whether the user already enrolled for any courses. Because user can enroll for 2 courses maximum at a time.
                        foreach (EnrollmentDetails enrollment in enrollmentList)
                        {
                            if (currentLoginUser.RegistrationID == enrollment.RegistrationID)
                            {
                                count++;
                            }
                            if (count == 2)
                            {
                                // 6.	If user already enrolled 2 courses,  
                                // find the course which has least course duration
                                //and calculate that course’s end date
                                // by using the enrollment date of that course and the course duration
                                foreach (CourseDetails course1 in courseList)
                                {
                                    int min = course1.CourseDuration;
                                    if (min > course1.CourseDuration)
                                    {
                                        min = course1.CourseDuration;
                                    } 
                                    System.Console.WriteLine($"Course's End Day is {enrollment.EnrollmentDate.AddDays(min)}");
                                } 
                                
                            }
                            else if (count < 2)
                            { 
                                EnrollmentDetails enrollmentn = new EnrollmentDetails(courseID, currentLoginUser.RegistrationID, DateTime.Today);
                                enrollmentList.Add(enrollmentn);
                                count++;
                            }
                        }


                        /*  if (count == 2)
                                { 
                                  foreach(EnrollmentDetails enrollment1 in enrollmentList)
                                  {
                                     if(currentLoginUser.RegistrationID == enrollment1.RegistrationID)
                                     {
                                        //DateTime max = DateTime.Now;
                                        foreach(CourseDetails course1 in courseList)
                                        {
                                            
                                        }
                                     }
                                  }


                                }
                                else if(count < 2)
                                { 
                                    EnrollmentDetails enrollmentn = new EnrollmentDetails(courseID,currentLoginUser.RegistrationID,DateTime.Today);
                                    enrollmentList.Add(enrollmentn);
                                    count++;
                                }
                                
                                else
                                { //7.	Print the next enrollable date . 
                                  // “You have already enrolled two courses
                                  // You can enroll next course on (course end date)”.

                                  System.Console.WriteLine($"You have already enrolled two courses. You can enroll next course on ");
                                }*/
                    }
                    else
                    { // If there is no seat available, display as “Seats are not available for the current course” and show the sub menu. 
                        System.Console.WriteLine("Seats are not available for the current course");
                        SubMenu();
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid CourseID. Please enter again");
            }
        }
        public static void ViewEnrollmentHistory()
        {
            foreach (EnrollmentDetails enrollment in enrollmentList)
            { // Show the course enrollment details of the current user
                if (currentLoginUser.RegistrationID == enrollment.RegistrationID)
                {
                    System.Console.WriteLine($" | {enrollment.CourseID,-15} | {enrollment.RegistrationID,-10} | {enrollment.EnrollmentDate.ToString("dd/MM/yyyy"),-15}");
                }
            }
        }

        public static void NextEnrollment()
        {

        }


    }
}