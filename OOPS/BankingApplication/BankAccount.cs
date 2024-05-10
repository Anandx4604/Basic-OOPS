using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum Gender { Select, Male, Female, Transgender }

namespace BankingApplication
{
    public class BankAccount
    {
        //field
        private static int s_customerID = 1000;
        //properties
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime DOB { get; set; }


        //Parameterised Constructor
        public BankAccount(string customerName, double balance, Gender gender, long phone, string mailID, DateTime dob)
        {
            s_customerID++;
            CustomerID = "HDFC" + s_customerID;
            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailID = mailID;
            DOB = dob;
        }

        public bool Deposit(double amount)
        {
            Balance += amount;
            return true;
        }

        public bool Withdraw(double amount)
        {

            if (amount>0 && amount<=Balance)
            {
                Balance -= amount;
                return true;
            }

            else
            {
                return false;
            }

        }


    }
}