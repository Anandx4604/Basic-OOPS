using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreApplication
{
    public static class Operations
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();
        static List<MedicineDetails> medicineList = new List<MedicineDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Default values...");
            // create objects
            // add to list
            // Traverse and show added data
            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", 9885858588, 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", 9888475757, 500);
            userList.Add(user1);
            userList.Add(user2);
            System.Console.WriteLine("| UserID | UserName    |   Age   |     City    |  Phone Number  |     Balance     |");
            System.Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (UserDetails user in userList)
            {
                System.Console.WriteLine($"{user.UserID,-5}  |  {user.UserName,-10}  |  {user.Age,-5}  |  {user.City,-10}  |  {user.PhoneNumber,-10}  |  {user.Balance,-10}  |");
            }

            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2023, 12, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(2023, 11, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(2024, 04, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(2026, 10, 30));
            medicineList.Add(medicine1);
            medicineList.Add(medicine2);
            medicineList.Add(medicine3);
            medicineList.Add(medicine4);
            medicineList.Add(medicine5);
            System.Console.WriteLine("\n| MedicineID |  Medicine Name  |   Available Count   |   Price   |  Date of Expiry  |");
            System.Console.WriteLine("---------------------------------------------------------------------------------------");
            foreach (MedicineDetails medicine in medicineList)
            {
                System.Console.WriteLine($"| {medicine.MedicineID,-10}  |  {medicine.MedicineName,-15}  |  {medicine.AvailableCount,-10}  |  {medicine.Price,-10}  |  {medicine.DateOfExpiry,-10:dd/MM/yyyy}  |");
            }

            OrderDetails order1 = new OrderDetails("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD2004", 2, 100, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD2003", 3, 120, new DateTime(2024, 01, 15), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD2005", 5, 250, new DateTime(2024, 01, 15), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD2002", 3, 15, new DateTime(2024, 01, 15), OrderStatus.Purchased);
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            orderList.Add(order4);
            orderList.Add(order5);
            orderList.Add(order6);
            System.Console.WriteLine("\n| OrderID  | UserID  |  MedicineID |  Medicine Count  | Total Price |  Order Date  | Order Status |");
            System.Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (OrderDetails order in orderList)
            {
                System.Console.WriteLine($"| {order.OrderID,-8} | {order.UserID,-8} | {order.MedicineID,-8}  |  {order.MedicineCount,-15}  |  {order.TotalPrice,-10}  |  {order.OrderDate,-10:dd/MM/yyyy}  |  {order.OrderStatus} |");
            }
        }
        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n Welcome to Online Medical Store");
                System.Console.WriteLine("1.User Registration  2.User Login  3.Exit");
                System.Console.Write("Select an option (1/2/3):");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
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
                            System.Console.WriteLine("Exiting the application...");
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
        public static void UserRegistration()
        {
            System.Console.WriteLine("---User Registration---");
            System.Console.Write("Enter your name:");
            string userName = Console.ReadLine();

            System.Console.Write("Enter your Age:");
            int age = int.Parse(Console.ReadLine());

            System.Console.Write("Enter your city:");
            string city = Console.ReadLine();

            System.Console.Write("Enter Phone number:");
            long phoneNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter Balance Amount:");
            double balance = double.Parse(Console.ReadLine());

            UserDetails newUser = new UserDetails(userName, age, city, phoneNumber, balance);
            userList.Add(newUser);

            System.Console.WriteLine($"Registered Successfully! Your User ID:{newUser.UserID}");
        }
        public static void UserLogin()
        {
            bool userFound = false;
            System.Console.WriteLine("---User Login---");
            System.Console.Write("Enter your UserID:");
            string userID = Console.ReadLine().ToUpper();
            foreach (UserDetails user in userList)
            {
                if (userID == user.UserID)
                {
                    userFound = true;
                    System.Console.WriteLine("Login Successful!");
                    currentLoginUser = user;
                    SubMenu();
                }
            }
            if (!userFound)
            {
                System.Console.WriteLine("Invalid UserID!");
            }
        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n---Submenu---");
                System.Console.WriteLine("1.Show Medicine list 2.Purchase medicine 3.Cancel purchase 4.Purchase history 5.Wallet Recharge 6.Show Wallet Balance 7.Exit");
                System.Console.Write("Select an option (1/2/3/4/5/6/7):");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            ShowMedicineList();
                            break;
                        }

                    case 2:
                        {
                            PurchaseMedicine();
                            break;
                        }

                    case 3:
                        {
                            CancelPurchase();
                            break;
                        }

                    case 4:
                        {
                            ShowPurchaseHistory();
                            break;
                        }

                    case 5:
                        {
                            IsWalletRecharge();
                            break;
                        }

                    case 6:
                        {
                            ShowWalletBalance();
                            break;
                        }

                    case 7:
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
        public static void ShowMedicineList()
        {
            System.Console.WriteLine("----- Medicine List -----");
            System.Console.WriteLine("\n| MedicineID |  Medicine Name  |   Available Count   |   Price   |  Date of Expiry  |");
            System.Console.WriteLine("---------------------------------------------------------------------------------------");
            foreach (MedicineDetails medicine in medicineList)
            {
                System.Console.WriteLine($"| {medicine.MedicineID,-10}  |  {medicine.MedicineName,-15}  |  {medicine.AvailableCount,-10}  |  {medicine.Price,-10}  |  {medicine.DateOfExpiry,-10:dd/MM/yyyy}  |");
            }
        }
        public static void PurchaseMedicine()
        {
            System.Console.WriteLine("----- Purchase Medicine -----");
            System.Console.WriteLine("Medicine List");
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("\n| MedicineID |  Medicine Name  |   Available Count   |   Price   |  Date of Expiry  |");
            System.Console.WriteLine("---------------------------------------------------------------------------------------");
            // 1.Show the List of medicine details by traversing the medicine details list.
            foreach (MedicineDetails medicine in medicineList)
            {
                System.Console.WriteLine($"| {medicine.MedicineID,-10}  |  {medicine.MedicineName,-15}  |  {medicine.AvailableCount,-10}  |  {medicine.Price,-10}  |  {medicine.DateOfExpiry,-10:dd/MM/yyyy}  |");
            }
            // 2.Ask the user to select the medicine using MedicineID.
            System.Console.WriteLine("Select an Medicine that you need!");
            System.Console.Write("Enter its MedicineID:");
            string medicineID = Console.ReadLine().ToUpper();
            // 3.Ask the number of counts of that medicine he wants to buy.
            System.Console.Write("Enter the Quantity of Medicine:");
            int medicineCount = int.Parse(Console.ReadLine());
            bool medicineFound = false;
            foreach (MedicineDetails medicine in medicineList)
            {
                // 4.Check the Medicine list whether the MedicineID was available. If it is available, then 
                if (medicineID == medicine.MedicineID)
                {
                    medicineFound = true;
                    // 4a.check the asked count is available.
                    if (medicineCount <= medicine.AvailableCount)
                    {
                        // If it is available, then Check the medicine was not expired.
                        if (medicine.DateOfExpiry > DateTime.Today)
                        {
                            // 4 c.If the medicine is not expired,                 
                            // If all the conditions specified in step 4 are true then calculate the total amount of purchased medicines, 
                            double totalPrice = (double)(medicineCount * medicine.Price);
                            // then check User has enough balance to purchase that medicine. 
                            if (currentLoginUser.Balance >= totalPrice)
                            {
                                //5.Reduce the number of AvailableCount of that medicine in MedicineDetails.
                                medicine.AvailableCount -= medicineCount;
                                //6.Deduct the total amount from user’s balance amount.
                                currentLoginUser.Balance -= totalPrice;
                                // 7. OrderDate is Now, Put OrderStatus as “Purchased” 
                                // and create object for OrderDetails class and add it to the list. 
                                OrderDetails newOrder = new OrderDetails(currentLoginUser.UserID, medicine.MedicineID, medicineCount, totalPrice, DateTime.Today, OrderStatus.Purchased);
                                orderList.Add(newOrder);
                                // 8.Finally show the message “Medicine was purchased successfully”.
                                System.Console.WriteLine($"Medicine {medicine.MedicineName} was purchased successfully");
                            }
                            else
                            {
                                // If the wallet balance is insufficient to purchsase the medicine, 
                                System.Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again!");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Medicine is Expired!");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine($"Medicine count is not available! Available count:{medicine.AvailableCount}");
                    }
                }

            }
            if (!medicineFound)
            {
                System.Console.WriteLine("Invalid MedicineID!");
            }
        }
        public static void CancelPurchase()
        {
            bool flag = true;
            System.Console.WriteLine("----- Cancel Purchase -----");
            System.Console.WriteLine("\n| OrderID  | UserID  |  MedicineID |  Medicine Count  | Total Price |  Order Date  | Order Status |");
            System.Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (OrderDetails order1 in orderList)
            {
                //1.Show the order details of the currently logged in user whose order status is “Purchased”.
                if (currentLoginUser.UserID == order1.UserID && order1.OrderStatus == OrderStatus.Purchased)
                {
                    flag = false;
                    System.Console.WriteLine($"| {order1.OrderID,-8} | {order1.UserID,-8} | {order1.MedicineID,-8}  |  {order1.MedicineCount,-15}  |  {order1.TotalPrice,-10}  |  {order1.OrderDate,-10:dd/MM/yyyy}  |  {order1.OrderStatus} |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No purchases Found!");
            }
            else
            {
                System.Console.WriteLine("Do you want to cancel any order?(yes/no)");
                string cancelOrder = Console.ReadLine().ToUpper();
                bool orderFound = false;
                // string cancelledOrderID = "";
                if (cancelOrder == "YES")
                {
                    System.Console.Write("Select an Order to Cancel! \nEnter OrderID:");
                    string orderID = Console.ReadLine().ToUpper();
                    foreach (OrderDetails order in orderList)
                    {
                        // 2.Get the OrderID information from the user 
                        // and check the OrderID present in the list and check its OrderStatus is Purchased.
                        if (orderID == order.OrderID && order.OrderStatus == OrderStatus.Purchased)
                        {
                            foreach (MedicineDetails medicine in medicineList)
                            {
                                //3.If the OrderID matches increase the count of that Medicine in the medicine details, 
                                if (order.MedicineID == medicine.MedicineID)
                                {
                                    medicine.AvailableCount += order.MedicineCount;
                                    // Return the amount to the user.  
                                    
                                    orderFound = true;
                                }
                            }
                            currentLoginUser.Balance += order.TotalPrice;
                                    //Change the order status to “Cancelled” 
                                    order.OrderStatus = OrderStatus.Cancelled;
                                    // Set flag to indicate order was found
                            System.Console.WriteLine($"Order {order.OrderID} cancelled successfully.");
                        }

                    }
                    if (!orderFound) // No order was found or cancelled
                    {
                        System.Console.WriteLine("Invalid OrderID");
                    }
                }
                else if (cancelOrder == "NO")
                {
                    SubMenu();
                }
            }
        }
        public static void ShowPurchaseHistory()
        {
            bool flag = true;
            System.Console.WriteLine("-----  Purchase History -----");
            System.Console.WriteLine("\n| OrderID  | UserID  |  MedicineID |  Medicine Count  | Total Price |  Order Date  | Order Status |");
            System.Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (OrderDetails order in orderList)
            {
                if (currentLoginUser.UserID == order.UserID)
                {
                    flag = false;
                    System.Console.WriteLine($"| {order.OrderID,-8} | {order.UserID,-8} | {order.MedicineID,-8}  |  {order.MedicineCount,-15}  |  {order.TotalPrice,-10}  |  {order.OrderDate,-10:dd/MM/yyyy}  |  {order.OrderStatus} |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No purchases found");
            }

        }
        public static void IsWalletRecharge()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("----- WalletRecharge -----");
                System.Console.WriteLine($"Current Wallet Balance:{currentLoginUser.Balance}");
                // 1.Ask the customer whether he wish to recharge the wallet.
                System.Console.WriteLine("Do you want to Recharge your Wallet? (yes/no)");
                string recharge = Console.ReadLine().ToLower();

                if (recharge == "yes")
                {
                    // 2.If “Yes” then ask for the amount to be recharged and update the amount in the wallet 
                    System.Console.Write("Enter Amount to Recharge:");
                    double amount = double.Parse(Console.ReadLine());
                    currentLoginUser.WalletRecharge(amount);

                    // and display the updated wallet balance.
                    System.Console.WriteLine($"Wallet Balance:{currentLoginUser.Balance}");

                }
                else
                {
                    flag = false;
                }
            } while (flag);

        }
        public static void ShowWalletBalance()
        {
            System.Console.WriteLine("---- WalletBalance -----");
            System.Console.WriteLine($"Balance Amount:{currentLoginUser.Balance}");
        }

    }
}