using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagementApplication
{

    public class Operations
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookDetailsList = new List<BookDetails>();
        static List<BorrowDetails> borrowDetailsList = new List<BorrowDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Default data...");
            System.Console.WriteLine("\n| UserID | User Name | Gender | Department | Mobile Number |      MailID      |");
            System.Console.WriteLine("-------------------------------------------------------------------------------");
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, 9938388333, "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, 9944444455, "priya@gmail.com", 150);
            userList.Add(user1);
            userList.Add(user2);

            foreach (UserDetails user in userList)
            {
                System.Console.WriteLine($"| {user.UserID,-5} | {user.UserName,-15}  |  {user.Gender,-10}  |  {user.Department,-5}  |  {user.MobileNumber,-10}  |  {user.EmailID,-15}  |  {user.WalletBalance,-5}");
            }

            System.Console.WriteLine("\n| BookID | Book Name | Author Name | Book Count |");
            System.Console.WriteLine("-------------------------------------------------------------------------------");
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            bookDetailsList.Add(book1);
            bookDetailsList.Add(book2);
            bookDetailsList.Add(book3);
            bookDetailsList.Add(book4);
            bookDetailsList.Add(book5);
            foreach (BookDetails book in bookDetailsList)
            {
                System.Console.WriteLine($"|  {book.BookID,-5}  |  {book.BookName,-10}  |  {book.AuthorName,-10}  |  {book.BookCount,-5}  |");
            }

            System.Console.WriteLine("\nBorrowID | BookID | UserID | BorrowedDate	| BorrowBookCount |	Status | PaidFineAmount");
            System.Console.WriteLine("-------------------------------------------------------------------------------");
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, BookStatus.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, BookStatus.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, BookStatus.Returned, 20);
            borrowDetailsList.Add(borrow1);
            borrowDetailsList.Add(borrow2);
            borrowDetailsList.Add(borrow3);
            borrowDetailsList.Add(borrow4);
            borrowDetailsList.Add(borrow5);

            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                System.Console.WriteLine($"|{borrow.BorrowID,-5}  |  {borrow.BookID,-5}  | {borrow.UserID,-5}  | {borrow.BorrowedDate,-15:dd/MM/yyyy}  |  {borrow.BorrowBookCount,-5}  | {borrow.BookStatus,-10}  |  {borrow.PaidFineAmount}");
            }


        }
        public static void Mainmenu()
        {
            System.Console.WriteLine("Main Menu");
            bool flag = true;
            do
            {
                System.Console.WriteLine("\n Welcome to Syncfusion Library");
                System.Console.WriteLine("1.User Registration \n2.User Login \n3.Exit");
                System.Console.Write("Select an option(1,2,3):");
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

            System.Console.Write("Enter your Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            System.Console.Write("Enter your Department:");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);

            System.Console.Write("Enter Mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.Write("Enter your email:");
            string emailID = Console.ReadLine();

            System.Console.Write("Enter Wallet Balance:");
            double walletBalance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName, gender, department, mobileNumber, emailID, walletBalance);
            userList.Add(user);

            System.Console.WriteLine($"Registered Successfully! Your User ID:{user.UserID}");

        }
        public static void UserLogin()
        {
            bool flag = true;
            System.Console.WriteLine("---- User Login ----");
            System.Console.Write("Enter your UserID:");
            string userID = Console.ReadLine().ToUpper();
            foreach (UserDetails user in userList)
            {
                if (userID == user.UserID)
                {
                    flag = false;
                    System.Console.WriteLine("Login Successful!");
                    currentLoginUser = user;
                    SubMenu();
                }

            }
            if (flag)
            {
                System.Console.WriteLine("Invalid UserID. Please enter a valid one");
            }
        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("----- Sub menu ------");
                System.Console.WriteLine("\n1.Borrowbook \n2.ShowBorrowedhistory \n3.ReturnBooks \n4.WalletRecharge \n5.Exit");
                System.Console.Write("Select an option(1/2/3/4/5):");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            BorrowBook();
                            break;
                        }

                    case 2:
                        {
                            ShowBorrowedHistory();
                            break;
                        }

                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }

                    case 4:
                        {
                            IsWalletRecharge();
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
        public static void BorrowBook()
        {
            bool flag = true;
            int totalBookCount = 0;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoginUser.UserID == borrow.UserID && borrow.BookStatus == BookStatus.Borrowed)
                {
                    totalBookCount += borrow.BorrowBookCount;
                }
            }
            System.Console.WriteLine("----- Borrow Book -----");
            // 1.	Show the list of Books available by printing BookID, BookName, AuthorName, BookCount.
            foreach (BookDetails book in bookDetailsList)
            {
                System.Console.WriteLine($"|  {book.BookID,-5}  |  {book.BookName,-10}  |  {book.AuthorName,-10}  |  {book.BookCount,-5}  |");
            }
            // 2.	Then Ask the user to pick one book by Asking “Enter Book ID to borrow”.
            System.Console.WriteLine("Enter Book ID to borrow");
            string bookID = Console.ReadLine().ToUpper();
            foreach (BookDetails book in bookDetailsList)
            {
                // 3.	Check whether “BookID” is available or not. 
                if (bookID == book.BookID)
                {
                    // int count = 0;
                    // ask the user to “Enter the count of the book”
                    flag = false;
                    System.Console.Write("Enter book count to borrow:");
                    int bookCount = int.Parse(Console.ReadLine());
                    // 5.	Check the book count availability of the book selected. 
                    if (bookCount <= book.BookCount)
                    {
                        // 6.	If the book is available to borrow, need to check whether the user already have any borrowed book. 
                        // Because user can have a maximum of only 3 borrowed books at a time. 
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (bookID == borrow.BookID)
                            {
                                if (totalBookCount == 3)
                                {
                                    // o	If user having 3 borrowed books already then show “You have borrowed 3 books already”.
                                    System.Console.WriteLine("You have already borrowed 3 books!");
                                    break;
                                }
                                else if (totalBookCount <= 3 && (totalBookCount + bookCount <= 3))
                                {
                                    // 7.	Else allocate the book to the user and set status of the Booking Details as "Borrowed” 
                                    // nd set the “BorrowedDate” as today’s date and “PaidFineAmount” as 0. 
                                    BorrowDetails newBorrow = new BorrowDetails(borrow.BookID, currentLoginUser.UserID, DateTime.Today, bookCount, BookStatus.Borrowed, 0);
                                    borrowDetailsList.Add(newBorrow);
                                    // borrow.BorrowedDate = DateTime.Today;
                                    // borrow.BookStatus = BookStatus.Borrowed;
                                    // borrow.PaidFineAmount = 0;
                                    // o	Create the Borrow Details object then store it and show “Book Borrowed successfully”.
                                    System.Console.WriteLine("Book Borrowed successfully");
                                    // Reduce the book count in book details list
                                    book.BookCount -= bookCount;
                                    borrow.BorrowBookCount++;
                                    break;
                                }

                                else if (totalBookCount + bookCount > 3)
                                {
                                    //If the user’s already borrowed book count and requested book count exceeds 3 count, 
                                    // then show “You can have maximum of 3 borrowed books. 
                                    // Your already borrowed books count is {BorrowBookCount} 
                                    // and requested count is {Current Requested Count}, which exceeds 3 ”.
                                    System.Console.WriteLine("You can only have maximum of 3 borrowed books.");
                                    System.Console.WriteLine($"Your already borrowed books count is {totalBookCount} and requested count is {bookCount}, which exceeds 3 ");
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        // If there is no book available, display as “Books are not available for the selected count”. 
                        System.Console.WriteLine("Books are not available for the selected count");
                        //And print the next available date of book by getting that book’s “BorrowedDate” from the borrowed history information
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (bookID == borrow.BookID && borrow.BookStatus == BookStatus.Borrowed)
                            {
                                //and adding with 15 days  the borrowed date of that book. 
                                DateTime nextAvailable = borrow.BorrowedDate.AddDays(15);
                                //Show “The book will be available on {borrowed date + 15 days}”.  
                                System.Console.WriteLine($"The book will be available on {nextAvailable:dd/MM/yyyy}");
                                break;

                            }
                        }
                    }
                }
            }
            if (flag)
            {
                // 4.	If not available display “ Invalid Book ID, Please enter valid ID”
                System.Console.WriteLine("Invalid BookID, Please enter valid ID");
            }
        }
        public static void ShowBorrowedHistory()
        {
            System.Console.WriteLine("------ Borrowed History ------");
            System.Console.WriteLine("\nBorrowID | BookID | UserID | BorrowedDate	| BorrowBookCount |	Status | PaidFineAmount");
            bool flag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoginUser.UserID == borrow.UserID)
                {
                    flag = false;
                    System.Console.WriteLine($"|{borrow.BorrowID,-5}  |  {borrow.BookID,-5}  | {borrow.UserID,-5}  | {borrow.BorrowedDate,-15:dd/MM/yyyy}  |  {borrow.BorrowBookCount,-5}  | {borrow.BookStatus,-10}  |  {borrow.PaidFineAmount}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No History found!");
            }
        }
        public static void ReturnBooks()
        {
            System.Console.WriteLine("----- Return Books -----");
            // bool sufficientBalance = true;
            bool flag = true;
            bool borrowed = true;
            double fineAmount = 0;
            // 1.	Show the borrowed book details of current user whose status is “borrowed” also Print the return date of each book (Return date will be 15 days after borrowing a book).  
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoginUser.UserID == borrow.UserID && borrow.BookStatus == BookStatus.Borrowed)
                {
                    flag = false;
                    DateTime after15days = borrow.BorrowedDate.AddDays(15);
                    System.Console.WriteLine($"Book: {borrow.BookID} should be returned by {after15days:dd/MM/yyyy}");
                    // 2.	If the return date is elapsed more than 15 days then calculate 
                    // and show the fine amount (Rs. 1 / Day) for each book.
                    int diffdays = (DateTime.Today - after15days).Days;

                    if (diffdays > 15)
                    {
                        fineAmount = diffdays * 1;
                        System.Console.WriteLine($"Book: {borrow.BookID} Fine Amount to be paid: {fineAmount}");
                    }
                    else
                    {
                        System.Console.WriteLine($"Book: {borrow.BookID} Fine Amount to be paid: {fineAmount}");
                    }

                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not borrowed any books yet!");
            }
            else
            {
                System.Console.Write("Enter your BorrowedID to return book:");
                string borrowID = Console.ReadLine().ToUpper();
                foreach (BorrowDetails borrow1 in borrowDetailsList)
                {
                    if (currentLoginUser.UserID == borrow1.UserID && borrow1.BookStatus == BookStatus.Borrowed)
                    {
                        // 3.	Ask him to select the BorrowedID to return book and validate that ID. 
                        if (borrowID == borrow1.BorrowID)
                        {
                            borrowed = false;
                            // 4.	If return date is elapsed, 
                            DateTime after15days = borrow1.BorrowedDate.AddDays(15);
                            int diffdays = (DateTime.Today - after15days).Days;
                            if (diffdays > 15)
                            {
                                fineAmount = diffdays * 1;
                                // a.	then check whether the user have sufficient balance for the fine amount, 
                                if (currentLoginUser.WalletBalance >= fineAmount)
                                {
                                    // sufficientBalance = false;
                                    // b.   if he has sufficient balance then deduct the fine amount from his Wallet balance 
                                    currentLoginUser.IsDeductBalance(fineAmount);
                                    //and change the Status in Booking History to “Returned” 
                                    // and update the fine amount to the “PaidFineAmount” calculated 
                                    borrow1.BookStatus = BookStatus.Returned;
                                    borrow1.PaidFineAmount = fineAmount;
                                    //and show “Book returned successfully”. Also, update the “BookCount”.
                                    System.Console.WriteLine("Book returned successfully");

                                    foreach (BookDetails book in bookDetailsList)
                                    {
                                        if (borrowID == book.BookID)
                                        {
                                            book.BookCount = borrow1.BorrowBookCount;
                                        }
                                    }

                                    // 5.   Else, change the Status in Booking History to “Returned” 
                                    // and show Book returned successfully. Also, update the “BookCount”.
                                }
                                else
                                {
                                    System.Console.WriteLine("Insufficient balance. Please recharge and proceed”. ");
                                    SubMenu();
                                }
                            }
                            else
                            {
                                borrow1.BookStatus = BookStatus.Returned;
                                foreach (BookDetails book in bookDetailsList)
                                {
                                    if (borrowID == book.BookID)
                                    {
                                        book.BookCount = borrow1.BorrowBookCount;
                                    }
                                }
                                System.Console.WriteLine("Book returned successfully.");
                            }
                        }
                    }
                }
            }
            if (borrowed)
            {
                System.Console.WriteLine("Invalid Book ID!");
            }

        }
        public static void IsWalletRecharge()
        {
            System.Console.WriteLine("----- Wallet Recharge ------");
            System.Console.WriteLine($"Current Balance:{currentLoginUser.WalletBalance}");
            System.Console.WriteLine("Do you want to Recharge?(Yes/No)");
            string option = Console.ReadLine().ToUpper();
            if (option == "YES")
            {
                System.Console.Write("Enter Amount to recharge:");
                double amount = double.Parse(Console.ReadLine());
                currentLoginUser.WalletRecharge(amount);
                System.Console.WriteLine("Recharged succesfully!");
                System.Console.WriteLine($"Wallet Balance:{currentLoginUser.WalletBalance}");
            }

        }

    }
}