using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDriveApplication
{

    public static class Operations
    {
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();
        static Beneficiary currentLoginBeneficiary;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding default values...");
            System.Console.WriteLine("Adding Beneficary default values...");
            Beneficiary beneficiary1 = new Beneficiary("Ravichandran", 21, Gender.Male, 8484484, "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 22, Gender.Male, 8484747, "Chennai");
            beneficiaryList.Add(beneficiary1);
            beneficiaryList.Add(beneficiary2);
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                System.Console.WriteLine($"|{beneficiary.RegistrationNumber,-5} | {beneficiary.Name,-15} | {beneficiary.Age,-5} | {beneficiary.Gender,-10} | {beneficiary.MobileNumber,-10} | {beneficiary.City} | ");
            }

            System.Console.WriteLine("Adding Vaccine default values...");
            Vaccine vaccine1 = new Vaccine(VaccineName.Covishield, 50);
            Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine, 50);
            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);
            foreach (Vaccine vaccine in vaccineList)
            {
                System.Console.WriteLine($"| {vaccine.VaccineID,-5} | {vaccine.VaccineName,-10}  |  {vaccine.NoOfDoseAvailable,-5} |");
            }

            System.Console.WriteLine("Adding Vaccination default values...");
            Vaccination vaccination1 = new Vaccination("BID1001", "CID2001", 1, new DateTime(2022, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "CID2001", 2, new DateTime(2023, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "CID2002", 1, new DateTime(2022, 04, 04));
            vaccinationList.Add(vaccination1);
            vaccinationList.Add(vaccination2);
            vaccinationList.Add(vaccination3);
            foreach (Vaccination vaccination in vaccinationList)
            {
                System.Console.WriteLine($"| {vaccination.VaccinationID,-5}  |  {vaccination.RegistrationNumber,-5}  |  {vaccination.VaccineID,-5}  |  {vaccination.DoseNumber,-5} |  {vaccination.VaccinatedDate:dd/MM/yyyy} |");
            }
        }
        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\nMain Menu");
                System.Console.WriteLine("\n1.Beneficiary Registration \n2.Login \n3.Get Vaccine Info \n4.Exit");
                System.Console.Write("Select a choice (1/2/3/4)");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            BeneficiaryRegistration();
                            break;
                        }

                    case 2:
                        {
                            Login();
                            break;
                        }

                    case 3:
                        {
                            GetVaccineInfo();
                            break;
                        }

                    case 4:
                        {
                            System.Console.WriteLine("Exiting the Application....");
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
        public static void BeneficiaryRegistration()
        {
            System.Console.WriteLine("----- Beneficiary Registration -----");
            System.Console.Write("Enter your Name:");
            string name = Console.ReadLine();
            System.Console.Write("Enter your Age:");
            int age = int.Parse(Console.ReadLine());
            System.Console.Write("Enter your Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.Write("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.Write("Enter your City:");
            string city = Console.ReadLine();

            Beneficiary newBeneficiary = new Beneficiary(name, age, gender, mobileNumber, city);
            beneficiaryList.Add(newBeneficiary);
            System.Console.WriteLine($"Registration Successful! Your Beneficiary Register Number:{newBeneficiary.RegistrationNumber}");
        }
        public static void Login()
        {
            bool flag = true;
            System.Console.WriteLine("----- Login -----");
            System.Console.Write("Enter your Beneficiary Register Number:");
            string registerNumber = Console.ReadLine().ToUpper();
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                if (registerNumber == beneficiary.RegistrationNumber)
                {
                    flag = false;
                    System.Console.WriteLine("Login Successful!");
                    currentLoginBeneficiary = beneficiary;
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Register Number");
            }
        }

        public static void GetVaccineInfo()
        {
            System.Console.WriteLine("----- Vaccine Info ------");
            foreach (Vaccine vaccine in vaccineList)
            {
                System.Console.WriteLine($"| {vaccine.VaccineID,-5} | {vaccine.VaccineName,-10}  |  {vaccine.NoOfDoseAvailable,-5} |");
            }

        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("----- SubMenu -----");
                System.Console.WriteLine("\n1.Show My Details \n2.Take Vaccination \n3.My Vaccination History \n4.Next Due Date  \n5.Exit");
                System.Console.Write("Select an option:(1/2/3/4/5):");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            ShowDetails();
                            break;
                        }

                    case 2:
                        {
                            TakeVaccination();
                            break;
                        }

                    case 3:
                        {
                            VaccinationHistory();
                            break;
                        }

                    case 4:
                        {
                            NextDueDate();
                            break;
                        }

                    case 5:
                        {
                            System.Console.WriteLine("Exiting Sub Menu....");
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
        public static void ShowDetails()
        {

            System.Console.WriteLine("------ Beneficiary Details ------");
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                if (currentLoginBeneficiary.RegistrationNumber == beneficiary.RegistrationNumber)
                {
                    System.Console.WriteLine($"|{currentLoginBeneficiary.RegistrationNumber,-5} | {currentLoginBeneficiary.Name,-15} | {currentLoginBeneficiary.Age,-5} | {currentLoginBeneficiary.Gender,-10} | {currentLoginBeneficiary.MobileNumber,-10} | {currentLoginBeneficiary.City} | ");
                }
            }

        }
        public static void TakeVaccination()
        {
            System.Console.WriteLine("----- Take Vaccination -----");
            

        }
        public static void VaccinationHistory()
        {
            System.Console.WriteLine("----- Vaccination History -----");
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (currentLoginBeneficiary.RegistrationNumber == vaccination.RegistrationNumber && vaccination.DoseNumber == 1 || vaccination.DoseNumber == 2 || vaccination.DoseNumber == 3)
                {
                    System.Console.WriteLine($"| {vaccination.VaccinationID,-5}  |  {vaccination.RegistrationNumber,-5}  |  {vaccination.VaccineID,-5}  |  {vaccination.DoseNumber,-5} |  {vaccination.VaccinatedDate:dd/MM/yyyy} |");
                }
            }
        }
        public static void NextDueDate()
        {
            bool flag = true;
            System.Console.WriteLine("----- Next Vaccination Due Date -----");
            DateTime nextDueDate = new DateTime();
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (currentLoginBeneficiary.RegistrationNumber == vaccination.RegistrationNumber)
                {
                    flag = false;
                    if (vaccination.DoseNumber == 0 || vaccination.DoseNumber == 1 )
                    {
                        if(vaccination.VaccinatedDate > DateTime.Today )
                        nextDueDate = vaccination.VaccinatedDate.AddDays(30);
                        System.Console.WriteLine($"Your Next Due Date:{nextDueDate:dd/MM/yyyy}");
                    }

                    if(vaccination.DoseNumber == 2)
                    {
                        System.Console.WriteLine("You have completed all vaccination. \nThanks for your participation in the vaccination drive");
                    }
                }

            }
            if (flag)
            {
                System.Console.WriteLine("you can take vaccine now." );
            }
        }
    }
}