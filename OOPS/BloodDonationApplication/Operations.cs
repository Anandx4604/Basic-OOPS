using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace BloodDonationApplication
{
    public static class Operations
    {
        static List<UserRegistration> donorList = new List<UserRegistration>();
        static List<Donation> donationList = new List<Donation>();
        static UserRegistration currentLoginUser;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("----- Adding Default Values -----");
            System.Console.WriteLine("\nAdding User Default data...");
            System.Console.WriteLine("| DonorID   |    Donor Name     |    Mobile    |     BloodGroup    |   Age   | Last Donation Date |");
            System.Console.WriteLine("---------------------------------------------------------------------------------------------------");
            UserRegistration user1 = new UserRegistration("Ravichandran", 8484848, BloodGroup.O_Positive, 30, new DateTime(2022, 08, 25));
            UserRegistration user2 = new UserRegistration("Baskaran", 4747447, BloodGroup.AB_Positive, 30, new DateTime(2022, 09, 30));
            donorList.Add(user1);
            donorList.Add(user2);
            foreach (UserRegistration donor in donorList)
            {
                System.Console.WriteLine($"|  {donor.DonorID,-5}  |  {donor.DonorName,-15}  |  {donor.MobileNumber,-10}  |  {donor.BloodGroup,-15}  |  {donor.Age,-5}  |  {donor.LastDonationDate,-15:dd/MM/yyyy}  |");
            }
            System.Console.WriteLine("\nAdding Donation Default data...");
            System.Console.WriteLine("|DonationID |  DonorID  |  Donation Date    |  Weight |   BP   | HB count |    Blood Group    |");
            System.Console.WriteLine("------------------------------------------------------------------------------------------------");
            Donation donation1 = new Donation("UID1001", new DateTime(2022, 06, 10), 73, 120, 14, BloodGroup.O_Positive);
            Donation donation2 = new Donation("UID1001", new DateTime(2022, 10, 10), 74, 120, 14, BloodGroup.O_Positive);
            Donation donation3 = new Donation("UID1002", new DateTime(2022, 07, 11), 74, 120, 13.6, BloodGroup.AB_Positive);
            donationList.Add(donation1);
            donationList.Add(donation2);
            donationList.Add(donation3);
            foreach (Donation donation in donationList)
            {
                System.Console.WriteLine($"|  {donation.DonationID,-5}  |  {donation.DonorID,-5}  |  {donation.DonationDate,-15:dd/MM/yyyy}  |  {donation.Weight,-5}  |  {donation.BloodPressure,-5}  |  {donation.HemoglobinCount,-5}  |  {donation.BloodGroup,-15}  |");
            }
        }
        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\nMain Menu");
                System.Console.WriteLine("1.User Registration \n2.User login \n3.Fetch Donor Details \n4.Exit");
                System.Console.Write("Select an option(1/2/3/4):");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }

                    case 2:
                        {
                            UserLogin();
                            break;
                        }

                    case 3:
                        {
                            FetchDonorDetails();
                            break;
                        }

                    case 4:
                        {
                            System.Console.WriteLine("\nExiting the application...");
                            flag = false;
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
        public static void Registration()
        {
            DateTime lastDonationDate;
            System.Console.WriteLine("----- User Registration -----");
            System.Console.Write("Enter your Name:");
            string donorName = Console.ReadLine();
            System.Console.Write("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.Write("Enter your Blood Group:");
            BloodGroup bloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            System.Console.Write("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Have you Donated blood before?(yes/no)");
            string checkDonation = Console.ReadLine().ToUpper();
            if (checkDonation == "YES")
            {
                System.Console.Write("Enter your Last Donation Date(dd//MM/yyyy):");
                lastDonationDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            }
            else
            {
                lastDonationDate = new DateTime(); //default date assigned as lastDonationDate
            }
            UserRegistration newDonor = new UserRegistration(donorName, mobileNumber, bloodGroup, age, lastDonationDate);
            donorList.Add(newDonor);
            System.Console.WriteLine("You have Registered Successfully!");
            System.Console.WriteLine($"Your DonorID :{newDonor.DonorID}");


        }
        public static void UserLogin()
        {
            System.Console.WriteLine("----- Login -----");
            System.Console.Write("Enter your DonorID:");
            string donorID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserRegistration donor in donorList)
            {
                if (donorID == donor.DonorID)
                {
                    flag = false;
                    System.Console.WriteLine("Login Successful!");
                    currentLoginUser = donor;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid UserID");
            }

        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n----- Submenu -----");
                System.Console.WriteLine("\n1.Donate Blood \n2.Donation History \n3.Next Eligible Date \n4.Exit");
                System.Console.Write("Select an option (1/2/3/4):");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            DonateBlood();
                            break;
                        }

                    case 2:
                        {
                            DonationHistory();
                            break;
                        }

                    case 3:
                        {
                            NextEligibleDate();
                            break;
                        }
                    case 4:
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
        public static void DonateBlood()
        {

            System.Console.WriteLine("----- Donate Blood -----");
            //  Get the weight, blood pressure, hemoglobin count from the user 
            // check Weight is above 50, bp is below 130 hemoglobin count is above 13.
            System.Console.Write("Enter your Weight:");
            double weight = double.Parse(Console.ReadLine());
            System.Console.Write("Enter your Blood Pressure:");
            double bloodPressure = double.Parse(Console.ReadLine());
            System.Console.Write("Enter your Hemoglobin Count:");
            double hemoglobinCount = double.Parse(Console.ReadLine());
            //Check whether the person’s completed 6 months after donating the blood.
            //If both the conditions met, then add the details to the “Donation Details” object and finally add to the list.
            if (weight > 50.0 && bloodPressure < 130.0 && hemoglobinCount > 13.0 && (DateTime.Now - currentLoginUser.LastDonationDate).TotalDays >= 180.0)
            {
                Donation newDonor = new Donation(currentLoginUser.DonorID, DateTime.Now, weight, bloodPressure, hemoglobinCount, currentLoginUser.BloodGroup);
                donationList.Add(newDonor);
                //updating last Donation date for new donor
                currentLoginUser.LastDonationDate = DateTime.Today;
                // Finally show Blood donated successfully, Show the donation ID And print the next eligible date of donation.
                // Next eligible date of donation is after 6 months from last time donor donate the blood.
                System.Console.WriteLine($"\nBlood donated successfully! by Donor ID:{currentLoginUser.DonorID}");
                Console.WriteLine($"The next eligible Date of Donation: {DateTime.Today.AddMonths(6):dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Blood donation criteria not met or not yet 6 months after last donation.");
            }
        }
        public static void DonationHistory()
        {
            bool flag = true;
            System.Console.WriteLine("----- Donation History -----");
            System.Console.WriteLine("|DonationID |  DonorID  |  Donation Date    |  Weight |   BP   | HB count |    Blood Group    |");
            System.Console.WriteLine("------------------------------------------------------------------------------------------------");
            foreach (Donation donation in donationList)
            {
                if (currentLoginUser.DonorID == donation.DonorID)
                {
                    flag = false;
                    System.Console.WriteLine($"|  {donation.DonationID,-5}  |  {donation.DonorID,-5}  |  {donation.DonationDate,-15:dd/MM/yyyy}  |  {donation.Weight,-5}  |  {donation.BloodPressure,-5}  |  {donation.HemoglobinCount,-5}  |  {donation.BloodGroup,-15}  |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have no Donation History! Donate Blood Soon!");
            }

        }
        public static void NextEligibleDate()
        {
            System.Console.WriteLine("----- Next Eligible Date -----");
            bool flag = true;
            // Show the next eligible date for the user (6 months from the date of last donation). 
            DateTime maxDonationDate = DateTime.MinValue;
            foreach (Donation donation in donationList)
            {
                if (currentLoginUser.DonorID == donation.DonorID)
                {
                    flag = false;
                    if (donation.DonationDate > maxDonationDate)
                    {
                        // If the user donates 2 times, last donation must be user recently donated date. 
                        //  Tax max day n fetch from donation list
                        maxDonationDate = donation.DonationDate;
                    }
                }
            }

            if (maxDonationDate != DateTime.MinValue)
            {
                // Calculate the next eligible date for donation (6 months from the maximum last donation date)
                DateTime nextEligibleDate = maxDonationDate.AddMonths(6);

                // Output the next eligible date for donation
                Console.WriteLine($"The next eligible Date of Donation: {nextEligibleDate:dd/MM/yyyy}");
            }
            // else
            // {
            //     System.Console.WriteLine($"The next eligible Date of Donation: {currentLoginUser.LastDonationDate.AddMonths(6):dd/MM/yyyy}");
            // }

            if(flag)
            {
                System.Console.WriteLine("You havent Donated blood yet!");
            }
        }
        public static void FetchDonorDetails()
        {
            System.Console.WriteLine("----- DonorDetails -----");
            // 1.	Ask for “Blood Group” and check blood group in the Donation details
            //  and it should display the donor’s name and phone number and native place
            System.Console.Write("Enter the Blood Group (A_Positive, B_Positive, O_Positive, AB_Positive):");
            // BloodGroup bloodGroup;
            if (!Enum.TryParse(Console.ReadLine(), true, out BloodGroup bloodGroup))
            {
                System.Console.WriteLine("Invalid Blood Group!");
                return;
            }
            bool found = false;
            foreach (Donation donation in donationList)
            {
                if (bloodGroup == donation.BloodGroup)
                {
                    found = true;
                    foreach (UserRegistration donor in donorList)
                    {
                        if (donor.BloodGroup == bloodGroup)
                        {
                            System.Console.WriteLine($"\nDonor Name: {donor.DonorName}  |  Mobile No: {donor.MobileNumber}");
                        }
                    }
                    break;
                }

            }
            if (!found)
            {
                System.Console.WriteLine(" No Donors found for the given BloodGroup!");
            }

        }

    }
}