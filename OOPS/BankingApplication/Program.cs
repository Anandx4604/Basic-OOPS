using System;
using System.Collections.Generic;
namespace BankingApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<BankAccount> customerList = new List<BankAccount>();
            string option = "";
            do
            {
                Console.WriteLine("Welcome to HDFC bank");
                Console.WriteLine("Main Menu \n1.Registration \n2.Login \n3.Exit");

                Console.Write("Select an option 1/2/3 : ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Registration
                            //Gender gender;
                            System.Console.Write("Enter your name: ");
                            string customerName = Console.ReadLine();

                            System.Console.Write("Enter Default balance: ");
                            double balance = double.Parse(Console.ReadLine());

                            System.Console.Write("Enter your Gender:");
                            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
                            // bool temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

                            // while (!temp)
                            // {
                            //     Console.WriteLine($"Invalid Gender! Re-enter Gender Correctly!");
                            //     temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
                            // }

                            System.Console.Write("Enter your Phone Number:");
                            long phone = long.Parse(Console.ReadLine());

                            System.Console.Write("Enter Date of birth (dd/MM/yyyy):");
                            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                            Console.Write("Enter your Mail ID:");
                            string mailID = Console.ReadLine();

                            BankAccount customer = new BankAccount(customerName, balance, gender, phone, mailID, dob);
                            Console.WriteLine($"\nYou are Bank Account is created Succesfully! \nYour Customer login ID: {customer.CustomerID}");
                            customerList.Add(customer);

                            System.Console.Write("\nDo you want to continue? yes/no: ");
                            option = Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            //Login
                            bool flag = true;
                            Console.Write("Enter Customer ID to Login: ");
                            string loginID = Console.ReadLine().ToUpper();
                            foreach (BankAccount customer in customerList)
                            {
                                if (loginID == customer.CustomerID)
                                {
                                    do
                                    {
                                        Console.WriteLine("\nSubMenu");
                                        Console.WriteLine("1.Deposit \n2.Withdraw \n3.Balance check \n4.Exit");
                                        Console.Write("\nSelect an option 1/2/3/4: ");
                                        int submenu = int.Parse(Console.ReadLine());
                                        switch (submenu)
                                        {
                                            case 1:
                                                {
                                                    Console.Write("Enter amount to Deposit:");
                                                    double amount = double.Parse(Console.ReadLine());
                                                    customer.Deposit(amount);
                                                    System.Console.WriteLine("Amount deposited sucessfully!");
                                                    System.Console.WriteLine($"Balance Amount:{customer.Balance}");
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    Console.Write("\nEnter amount to Withdraw:");
                                                    double amount = double.Parse(Console.ReadLine());
                                                    bool IsSucess = customer.Withdraw(amount);
                                                    if (IsSucess)
                                                    {
                                                        System.Console.WriteLine($"Amount: {amount} withdrawn sucessfully!");
                                                        System.Console.WriteLine($"Balance Amount:{customer.Balance}");
                                                    }
                                                    else
                                                    {
                                                        System.Console.WriteLine("Insufficient Balance! Try Different amount");
                                                        System.Console.WriteLine($"Balance Amount:{customer.Balance}");
                                                    }
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    System.Console.WriteLine($"Balance Amount:{customer.Balance}");
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
                                                    Console.WriteLine("Invalid option!");
                                                    break;
                                                }
                                        }


                                    } while (flag == true);
                                }

                                else
                                {
                                    System.Console.WriteLine("\nInvalid LoginID! Enter correct LoginID");
                                }

                            }
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("\nExiting application....");
                            option = "no";
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nInvalid Option! Try Again!");
                            break;
                        }
                }
            } while (option == "yes");

        }
    }
















}