using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DTHRechargeApplication
{
    public static class Operations
    {
        static List<UserRegistration> userRegistrationList = new List<UserRegistration>();
        static List<PackDetails> packDetailsList = new List<PackDetails>();
        static List<RechargeHistory> rechargeHistoryList = new List<RechargeHistory>();
        static UserRegistration currentLoginUser;

        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Defaut Data...");
            System.Console.WriteLine("Adding User Registration default values...");
            UserRegistration user1 = new UserRegistration("John", 9746646466, "john@gmail.com", 500);
            UserRegistration user2 = new UserRegistration("Merlin", 9782136543, "merlin@gmail.com", 150);
            userRegistrationList.Add(user1);
            userRegistrationList.Add(user2);
            foreach (UserRegistration user in userRegistrationList)
            {
                System.Console.WriteLine($"{user.UserName,-10}  |  {user.MobileNumber,-10}  | {user.EmailID,-20}  | {user.WalletBalance,-5} |");
            }

            System.Console.WriteLine("Adding Pack Details default values...");
            PackDetails pack1 = new PackDetails("RC150", "Pack1", 150, 28, 50);
            PackDetails pack2 = new PackDetails("RC300", "Pack2", 300, 56, 75);
            PackDetails pack3 = new PackDetails("RC500", "Pack3", 500, 28, 200);
            PackDetails pack4 = new PackDetails("RC1500", "Pack4", 1500, 365, 200);
            packDetailsList.Add(pack1);
            packDetailsList.Add(pack2);
            packDetailsList.Add(pack3);
            packDetailsList.Add(pack4);

            foreach (PackDetails pack in packDetailsList)
            {
                System.Console.WriteLine($"{pack.PackID,-10}  |  {pack.PackName,-5}  | {pack.Price,-10}  | {pack.Validity,-5} | {pack.NoOfChannels,-5} |");
            }

            System.Console.WriteLine("Adding Recharge History Details default values...");
            RechargeHistory history1 = new RechargeHistory("UID1001", "RC150", new DateTime(2021, 11, 30), 150, new DateTime(2021, 12, 27), 50);
            RechargeHistory history2 = new RechargeHistory("UID1002", "RC150", new DateTime(2022, 01, 01), 150, new DateTime(2022, 01, 28), 50);

            rechargeHistoryList.Add(history1);
            rechargeHistoryList.Add(history2);

            foreach (RechargeHistory history in rechargeHistoryList)
            {
                System.Console.WriteLine($"{history.RechargeID,-5}  |  {history.UserID,-5}  | {history.PackID,-5}  | {history.RechargeDate,-20:dd/MM/yyyy} | {history.RechargeAmount,-5}  |  {history.ValidTill,-20:dd/MM/yyyy} | {history.NoOfChannels,-5} |");
            }

        }

        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\nMain Menu");
                System.Console.WriteLine("1.User Registration \n2.User Login \n3.Exit");
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
                            System.Console.WriteLine("Exiting application...");
                            flag = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Inavlid option!");
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegistration()
        {
            System.Console.WriteLine("---- User Registration -----");
            System.Console.Write("Enter your name:");
            string userName = Console.ReadLine();
            System.Console.Write("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.Write("Enter your mailID:");
            string emailID = Console.ReadLine();
            System.Console.Write("Enter your Wallet Balance:");
            double walletBalance = double.Parse(Console.ReadLine());

            UserRegistration user = new UserRegistration(userName, mobileNumber, emailID, walletBalance);
            userRegistrationList.Add(user);
            System.Console.WriteLine($"You Registered Successfully! Your UserID:{user.UserID}");


        }

        public static void UserLogin()
        {
            bool flag = true;
            System.Console.WriteLine("----- User Login -----");
            System.Console.Write("Enter your UserID:");
            string userID = Console.ReadLine().ToUpper();

            foreach (UserRegistration user in userRegistrationList)
            {
                if (userID == user.UserID)
                {
                    System.Console.WriteLine("Logged in Successfully!");
                    currentLoginUser = user;
                    flag = false;
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid UserID!");
            }

        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n----- Sub Menu -----");
                System.Console.WriteLine("1.Current Pack 2.Pack Recharge 3. Wallet Recharge 4.View Pack Recharge History 5.Show Wallet Balance 6.Exit");
                System.Console.Write("Select an option(1/2/3/4/5/6):");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            CurrentPack();
                            break;
                        }

                    case 2:
                        {
                            PackRecharge();
                            break;
                        }

                    case 3:
                        {
                            IsWalletRecharge();
                            break;
                        }

                    case 4:
                        {
                            ViewPackRechargeHistory();
                            break;
                        }

                    case 5:
                        {
                            ShowWalletBalance();
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

        public static void CurrentPack()
        {
            bool flag = true;
            System.Console.WriteLine("----- Current Pack -----");
            //1.Displays recent pack detail of current user 
            // (User ID, Pack ID, Recharge Amount, Valid Till, Number of channels)
            foreach (RechargeHistory history in rechargeHistoryList)
            {
                if (currentLoginUser.UserID == history.UserID && history.ValidTill >= DateTime.Now)
                {
                    System.Console.WriteLine($"|  {history.UserID,-5}  | {history.PackID,-5} | {history.RechargeAmount,-5}  |  {history.ValidTill,-20:dd/MM/yyyy} | {history.NoOfChannels,-5} |");
                    flag = false;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You Don't have any plans! Please Recharge it soon!");
            }
        }

        public static void PackRecharge()
        {
            bool flag = true;
            System.Console.WriteLine("----- Pack Recharge -----");
            //List the available pack details and ask the user to choose a pack and recharge.
            foreach (PackDetails packs in packDetailsList)
            {
                System.Console.WriteLine($"{packs.PackID,-10}  |  {packs.PackName,-5}  | {packs.Price,-10}  | {packs.Validity,-5} | {packs.NoOfChannels,-5} |");

            }
            System.Console.WriteLine("Choose a Pack to Recharge!");
            System.Console.Write("Enter PackID:");
            string selectedPack = Console.ReadLine().ToUpper();
            // 2.Based on the pack choose, check the wallet balance.
            foreach (PackDetails pack in packDetailsList)
            {
                if (selectedPack == pack.PackID)
                {
                    flag = false;
                    // 4.If the user has sufficient balance, then permit and do recharge.
                    // 	4. Current pack till 30 days - recharge after that 30 days.
                    //  5. Pack 1 + pack 2+ after 60 days
                    if (currentLoginUser.WalletBalance >= pack.Price)
                    {
                        DateTime temp = new DateTime();
                        foreach (RechargeHistory history in rechargeHistoryList)
                        {
                            if (currentLoginUser.UserID == history.UserID)
                            {
                                temp = history.ValidTill;
                            }
                        }
                        DateTime rechargeValidity = DateTime.Today.AddDays(pack.Validity - 1);
                        if (temp >= DateTime.Today)
                        {
                            rechargeValidity = DateTime.Today.Add(temp - DateTime.Today).AddDays(pack.Validity);
                        }
                        RechargeHistory newHistory = new RechargeHistory(currentLoginUser.UserID, pack.PackID, DateTime.Today, pack.Price, rechargeValidity, pack.NoOfChannels);
                        rechargeHistoryList.Add(newHistory);
                        //deducting balance based on pack price chosen
                        currentLoginUser.WalletBalance -= pack.Price;
                        System.Console.WriteLine("Recharged your DTH successfully!");
                    }
                    else
                    {
                        // 3.If insufficient balance in wallet, ask them to recharge his wallet.
                        System.Console.WriteLine("You have insufficient balance! Please recharge your wallet!");
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Wrong PackID! Enter correctly");
            }
            //showing recharge history to user after recharge or letting user know what pack recharged last.
            ViewPackRechargeHistory();
        }

        public static void IsWalletRecharge()
        {
            System.Console.WriteLine("----- Wallet Recharge -----");
            // Ask for the amount to be recharged from the user and update the wallet balance.
            System.Console.Write("Enter amount to recharge:");
            double amount = double.Parse(Console.ReadLine());
            currentLoginUser.WalletRecharge(amount);
            System.Console.WriteLine($"Wallet Balance:{currentLoginUser.WalletBalance}");
        }

        public static void ViewPackRechargeHistory()
        {
            bool flag = true;
            System.Console.WriteLine("----- Recharge History -----");
            // List the history of recharge details of current user 
            // (UserID, PackID, Recharge Amount, Valid Till)
            foreach (RechargeHistory history in rechargeHistoryList)
            {
                if (currentLoginUser.UserID == history.UserID)
                {
                    flag = false;
                    System.Console.WriteLine($"|  {history.UserID,-5}  | {history.PackID,-5} | {history.RechargeAmount,-5}  |  {history.ValidTill,-20:dd/MM/yyyy} |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You don't have any Recharge History! Please Recharge it soon!");
            }
        }

        public static void ShowWalletBalance()
        {
            System.Console.WriteLine("----- Wallet Balance -----");
            // show the wallet balance of the current user
            System.Console.WriteLine($"Wallet Balance:{currentLoginUser.WalletBalance}");
        }
    }
}