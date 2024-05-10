using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication
{
    public static class Operation
    {
        // create List for all classes
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        public static CustomerDetails currentLoginCustomer;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Default values");
            // create objects
            // add to list
            // Traverse and show added data
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");
            customerList.Add(customer1);
            customerList.Add(customer2);

            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);

            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);

            OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID3002", "PID2002", 40000, DateTime.Now, 2, OrderStatus.Ordered);

            orderList.Add(order1);
            orderList.Add(order2);

            System.Console.WriteLine("---Adding Customer Default data---");
            foreach (CustomerDetails customer in customerList)
            {
                System.Console.WriteLine($"{customer.CustomerID,-5} |  {customer.CustomerName,-10}  | {customer.City,-10}  | {customer.MobileNumber,-10}  | {customer.WalletBalance} | {customer.EmailID} |");
            }

            System.Console.WriteLine("---Adding Product Default data---");
            foreach (ProductDetails product in productList)
            {
                System.Console.WriteLine($"{product.ProductID,-5} | {product.ProductName,-20} | {product.Stock,-5} | {product.Price,-5} | {product.ShippingDuration,-5} |");
            }

            System.Console.WriteLine("---Adding Order Default data---");
            foreach (OrderDetails order in orderList)
            {
                System.Console.WriteLine($"{order.OrderID,-5} | {order.CustomerID,-5} | {order.ProductID,-5} | {order.TotalPrice,-5} | {order.PurchaseDate,-10} | {order.Quantity,-5} | {order.OrderStatus,-10} |");
            }

        }
        public static void Mainmenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n Welcome to SyncCart");
                System.Console.WriteLine("1.Customer Registration  2.Login  3.Exit");
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
        public static void Registration()
        {
            System.Console.WriteLine("---Customer Registration---");
            System.Console.Write("Enter your name:");
            string customerName = Console.ReadLine();

            System.Console.Write("Enter your city:");
            string city = Console.ReadLine();

            System.Console.Write("Enter Mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter Wallet Balance:");
            double walletBalance = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your email");
            string emailID = Console.ReadLine();

            CustomerDetails customer = new CustomerDetails(customerName, city, mobileNumber, walletBalance, emailID);
            customerList.Add(customer);

            System.Console.WriteLine($"Registered Successfully! Your Customer ID:{customer.CustomerID}");
        }
        public static void Login()
        {

            Console.WriteLine("\nCustomer Login");
            //get userID
            //traverse student list
            //find user id  is present
            //if user id not present show invalid user id
            //if user id is present store current login cookie object   globally
            //Then show submenu
            System.Console.Write("Enter your CustomerID:");
            string customerID = Console.ReadLine().ToUpper();

            bool flag = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customerID == customer.CustomerID)
                {
                    System.Console.WriteLine("Login Successful!");
                    flag = false;
                    currentLoginCustomer = customer;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                System.Console.WriteLine("Invalid CustomerID!");
            }

        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n---Submenu---");
                System.Console.WriteLine("1.Purchase 2.Order History 3.Cancel Order 4.Wallet Balance 5.Wallet Recharge 6.Exit");
                System.Console.Write("Select an option (1/2/3/4/5/6):");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Purchase();
                            break;
                        }

                    case 2:
                        {
                            OrderHistory();
                            break;
                        }

                    case 3:
                        {
                            CancelOrder();
                            break;
                        }

                    case 4:
                        {
                            WalletBalance();
                            break;
                        }

                    case 5:
                        {
                            IsWalletRecharge();
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
        public static void Purchase()
        {
            System.Console.WriteLine("Purchase option");
            System.Console.WriteLine("----- Product details -----");
            int deliveryCharge = 50;
            bool flag = true;
            System.Console.WriteLine("ProductID| ProductName       | Stock | Price | Shipping Duration");
            foreach (ProductDetails product in productList)
            {
                System.Console.WriteLine($"{product.ProductID,-5} | {product.ProductName,-20} | {product.Stock,-5} | {product.Price,-5} | {product.ShippingDuration,-5} |");
            }
            // 1.Once the Customer logged in show the list of Products
            // Ask the customer to select a Product using Product ID. 
            System.Console.WriteLine("Choose Product you want to purchase");
            System.Console.Write("Enter its ProductID:");
            string productID = Console.ReadLine().ToUpper();
            foreach (ProductDetails product in productList)
            {
                //2.Validate productID if it is invalid show “Invalid ProductID”. 
                if (productID == product.ProductID)
                {
                    flag = false;
                    //3.If it is valid, Then ask for the count he wish to purchase.
                    System.Console.WriteLine("Enter Quantity of Buying Product:");
                    int quantity = int.Parse(Console.ReadLine());
                    // 4.If the required count is not available in the product’s stock,
                    if (quantity > product.Stock || product.Stock == 0)
                    {
                        //  then show like “Required count not available.Current availability is { product’s stock count }”.
                        System.Console.WriteLine($"Required count not available. \nCurrent availability is {product.Stock}");
                    }
                    else if (quantity <= product.Stock && quantity > 0)
                    {
                        // 5.If the count is available calculate total amount with the below formula.
                        // Delivery charge is Rs 50
                        // Total Amount = (required count * price per quantity) +Delivery charge
                        double totalAmount = (quantity * product.Price) + deliveryCharge;
                        //6.Check the current logged in customer’s wallet balance 
                        // to ensure he is having enough balance to purchase by comparing with total price.
                        if (totalAmount <= currentLoginCustomer.WalletBalance)
                        {
                            // 8.If the wallet has sufficient balance, then
                            // a.Deduct the total amount from the wallet balance of the current logged in customer.
                            currentLoginCustomer.WalletBalance -= totalAmount;

                            // b.Deduct the count from the stock availability of the product.
                            product.Stock -= quantity;

                            // 9.Create order with available details and make its status as Ordered, 
                            OrderDetails newOrder = new OrderDetails(currentLoginCustomer.CustomerID, product.ProductID, totalAmount, DateTime.Now, quantity, OrderStatus.Ordered);
                            // add it to order List
                            orderList.Add(newOrder);
                            // Order Placed Successfully.Order ID: OID1001
                            System.Console.WriteLine($"Order Placed Successfully. Order ID:{newOrder.OrderID,-5}");
                            // 10.	Show the delivery date of order by making a calculation based on purchase date
                            //  and shipping duration of the product like “Order placed successfully. 
                            // Your order will be delivered on {Order date +shipping duration of the product}.
                            System.Console.WriteLine($"Your order will be delivered on {DateTime.Now.AddDays(product.ShippingDuration):dd/MM/yyyy}");
                        }
                        else
                        {
                            // 7.If the wallet balance is insufficient for this order, 
                            // then display “Insufficient Wallet Balance.Please recharge your wallet and do purchase again”.
                            System.Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again!");
                        }

                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid ProductID");
            }
        }
        public static void OrderHistory()
        {
            System.Console.WriteLine("OrderHistory option");
            bool flag = true;
            //Show all the information about the orders that current logged in customer made.
            foreach (OrderDetails order in orderList)
            {
                if (currentLoginCustomer.CustomerID == order.CustomerID)
                {
                    flag = false;
                    System.Console.WriteLine($"{order.OrderID,-5} | {order.CustomerID,-5} | {order.ProductID,-5} | {order.TotalPrice,-5} | {order.PurchaseDate,-10} | {order.Quantity,-5} | {order.OrderStatus,-10} |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No Order History found!");
            }
        }

        /* public static void CancelOrder()
         {
             System.Console.WriteLine("----- Cancel Order -----");

             bool flag1 = true;
             foreach (OrderDetails order in orderList)
             {
                 bool flag = true;
                 string cancelOrder = "";
                 //  1.	Show all orders placed by current logged in customer whose order status is Ordered.
                 if (currentLoginCustomer.CustomerID == order.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                 {
                     flag1 = false;
                     System.Console.WriteLine("\n --- Order Details ---");
                     System.Console.WriteLine($"{order.OrderID,-5} | {order.CustomerID,-5} | {order.ProductID,-5} | {order.PurchaseDate,-10} | {order.Quantity,-5} | {order.OrderStatus,-10} |");

                     //  2.  Ask customer to select an order to be cancelled by the OrderID.
                     do
                     {
                         System.Console.WriteLine("Do you want to cancel any order?(yes/no)");
                         cancelOrder = Console.ReadLine().ToLower();
                         if (cancelOrder == "yes")
                         {
                             System.Console.Write("Select an Order to Cancel! \nEnter OrderID:");
                             string orderID = Console.ReadLine().ToUpper();
                             //  3.	Validate orderID and show “Invalid OrderID” if there is no such order.
                             if (orderID == order.OrderID)
                             {
                                 //  4.	If it is valid then Pick the order based on the provided OrderID.
                                 foreach (ProductDetails product in productList)
                                 {
                                     if (order.ProductID == product.ProductID)
                                     {
                                         //  5.	Increase the available stock quantity by the count of product purchased in the current order to be cancelled. order.OrderID
                                         product.Stock += order.Quantity;
                                         //  6.	Refund the amount to the customer’s wallet balance.
                                         currentLoginCustomer.WalletBalance += product.Price;
                                         // 7.	Change the order status to “Cancelled” 
                                         order.OrderStatus = OrderStatus.Cancelled;
                                         Console.WriteLine($"Order Cancelled Successfully. Order ID: {order.OrderID}");
                                         flag = false;
                                         break; // Exit productList iteration once the product is foundF

                                     }
                                     else
                                     {
                                         System.Console.WriteLine("Invalid OrderID");
                                     }
                                 }
                             }
                             else if (cancelOrder == "no")
                             {
                                 flag = false;
                                 break;
                             }
                             else
                             {
                                 System.Console.WriteLine("\nInvalid choice! Enter correct option(yes/no)");
                             }

                             // foreach (OrderDetails order1 in orderList)
                             // {
                             //     if (currentLoginCustomer.CustomerID == order1.CustomerID && order1.OrderStatus == OrderStatus.Cancelled)
                             //     {
                             //         //  and finally show “Order :{OrderID} cancelled successfully”.
                             //         System.Console.WriteLine($"Order Cancelled Successfully. Order ID:{order.OrderID,-5}");
                             //     }
                             // }

                         }


                     } while (flag);
                 }


             }
             if (flag1)
             {
                 System.Console.WriteLine("You didn't Purchase any Products!");
             }

         }*/
        public static void CancelOrder()
        {
            System.Console.WriteLine("----- Cancel Order -----");
            bool flag = true;
            foreach (OrderDetails order1 in orderList)
            {
                if (currentLoginCustomer.CustomerID == order1.CustomerID)
                {
                    flag = false;
                    System.Console.WriteLine($"{order1.OrderID,-5} | {order1.CustomerID,-5} | {order1.ProductID,-5} | {order1.PurchaseDate,-10} | {order1.Quantity,-5} | {order1.OrderStatus,-10} |");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No orders found to cancel!");
            }
            else
            {
                System.Console.WriteLine("Do you want to cancel any order?(yes/no)");
                string cancelOrder = Console.ReadLine().ToUpper();
                bool orderFound = false;
                string cancelledOrderID = "";
                if (cancelOrder == "YES")
                {
                    System.Console.Write("Select an Order to Cancel! \nEnter OrderID:");
                    string orderID = Console.ReadLine().ToUpper();
                    foreach (OrderDetails order in orderList)
                    {
                        //  3.	Validate orderID and show “Invalid OrderID” if there is no such order.
                        if (orderID == order.OrderID && order.OrderStatus == OrderStatus.Ordered)
                        {
                            //  4.	If it is valid then Pick the order based on the provided OrderID.
                            foreach (ProductDetails product in productList)
                            {
                                if (order.ProductID == product.ProductID)
                                {
                                    //  5.	Increase the available stock quantity by the count of product purchased in the current order to be cancelled. order.OrderID
                                    product.Stock += order.Quantity;

                                }
                            }
                            //  6.	Refund the amount to the customer’s wallet balance without delivery charge.
                            currentLoginCustomer.WalletBalance += order.TotalPrice - 50.0;
                            // 7.	Change the order status to “Cancelled” 
                            order.OrderStatus = OrderStatus.Cancelled;
                            // Set flag to indicate order was found
                            orderFound = true;
                            // Store the ID of the cancelled order
                            cancelledOrderID = order.OrderID;
                            // Exit the inner loop once the order is cancelled
                            break;
                            // if (orderFound)
                            // {
                            //     // Exit the outer loop once the order is found and cancelled
                            //     break;
                            // }
                        }
                        else if (orderID == order.OrderID && order.OrderStatus == OrderStatus.Cancelled)
                        {
                            orderFound = true;
                            System.Console.WriteLine("You have already Cancelled this product");
                        }
                    }
                    if (orderFound == false) // No order was found or cancelled
                    {
                        System.Console.WriteLine("Invalid OrderID");
                    }
                    else // An order was found and cancelled
                    {
                        Console.WriteLine($"Order {cancelledOrderID} cancelled successfully.");
                    }
                }
            }
        }
        public static void WalletBalance()
        {
            System.Console.WriteLine("----- WalletBalance -----");
            //    Show the current available WalletBalance of current logged in customer.


            System.Console.WriteLine($"{currentLoginCustomer.WalletBalance}");

        }
        public static void IsWalletRecharge()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("----- WalletRecharge -----");
                System.Console.WriteLine($"Current Wallet Balance:{currentLoginCustomer.WalletBalance}");
                // 1.Ask the customer whether he wish to recharge the wallet.
                System.Console.WriteLine("Do you want to Recharge your Wallet? (yes/no)");
                string recharge = Console.ReadLine().ToLower();

                if (recharge == "yes")
                {
                    // 2.If “Yes” then ask for the amount to be recharged and update the amount in the wallet 
                    System.Console.Write("Enter Amount to Recharge:");
                    double amount = double.Parse(Console.ReadLine());
                    currentLoginCustomer.WalletRecharge(amount);

                    // and display the updated wallet balance.
                    System.Console.WriteLine($"Wallet Balance:{currentLoginCustomer.WalletBalance}");

                }
                else
                {
                    flag = false;
                }
            } while (flag);

        }
    }
}