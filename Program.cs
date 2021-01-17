using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{

    class Transaction
    {
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public string TransactionValue { get; set; }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var transactions = new List<Transaction>()
            {
                new Transaction() {
                  AccountType = "Savings",
                  TransactionType = "Deposit",
                  TransactionValue = "25",
                },
                new Transaction() {
                  AccountType = "Checking",
                  TransactionType = "Deposit",
                  TransactionValue = "10",
                },
                new Transaction() {
                  AccountType = "Savings",
                  TransactionType = "Deposit",
                  TransactionValue = "25",
                },
                new Transaction() {
                  AccountType = "Savings",
                  TransactionType = "Withdrawal",
                  TransactionValue = "5",
                },
                new Transaction() {
                  AccountType = "Checking",
                  TransactionType = "Withdrawal",
                  TransactionValue = "20",
                },

            };

            static void BannerMessage(string message)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*******************************");
                Console.WriteLine();
                Console.WriteLine(message);
                Console.WriteLine();
                Console.WriteLine("*******************************");
                Console.WriteLine();
                Console.WriteLine();
            };

            BannerMessage("Welcome to First Bank of Suncoast");

            Console.WriteLine("Would you like to make a Deposit or Withdrawal?");
            var newTransactionType = Console.ReadLine();
            // Console.WriteLine(newTransactionType);

            if (newTransactionType == "Deposit" || newTransactionType == "deposit" || newTransactionType == "Checking" || newTransactionType == "checking")
            {
                Console.WriteLine("Please select an account:");
                Console.WriteLine("- Checking");
                Console.WriteLine("- Savings");
                var newAccountType = Console.ReadLine();

                if (newAccountType == "Savings" || newAccountType == "savings" || newAccountType == "Checking" || newAccountType == "checking")
                {
                    // Console.WriteLine(newAccountType);
                    Console.WriteLine("Enter a $ amount");
                    var newTransactionValue = Console.ReadLine();

                    var newTransaction = new Transaction()
                    {
                        AccountType = newAccountType,
                        TransactionType = newTransactionType,
                        TransactionValue = newTransactionValue,
                    };
                    transactions.Add(newTransaction);

                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine($"{transaction.TransactionType} ${transaction.TransactionValue} into {transaction.AccountType} ");
                    };
                }
                else
                {
                    Console.WriteLine("Invalid Account Type entered, process canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type Entered, process canceled.");
            }



        }
    }
}
