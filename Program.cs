using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

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
            static List<Transaction> ReadTransactions(string nameOfFileToReadTransactionsFrom)
            {
                using var fileReader = new StreamReader(nameOfFileToReadTransactionsFrom);
                using var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                return csvReader.GetRecords<Transaction>().ToList();

                fileReader.Close();
            }

            List<Transaction> transactions = ReadTransactions("transactions.csv");

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

            static void ErrorMessage(string message)
            {

                Console.WriteLine("*******************************");
                Console.WriteLine();
                Console.WriteLine(message);
                Console.WriteLine();
                Console.WriteLine("*******************************");

            };
            BannerMessage("Welcome to First Bank of Suncoast");


            bool hasQuit = false;
            while (hasQuit == false)
            {

                Console.WriteLine("Please select an Account Type or Cancel to exit:");
                Console.WriteLine("- Checking");
                Console.WriteLine("- Savings");
                Console.WriteLine("- Cancel");
                var newAccountType = Console.ReadLine();

                // Console.WriteLine(newTransactionType);
                if (newAccountType == "Cancel" || newAccountType == "cancel")
                {
                    hasQuit = true;
                }
                else if (newAccountType == "Savings" || newAccountType == "savings" || newAccountType == "Checking" || newAccountType == "checking")
                {
                    Console.WriteLine("Would you like to make a Deposit or Withdrawal?");
                    var newTransactionType = Console.ReadLine();

                    if (newTransactionType == "Deposit" || newTransactionType == "deposit" || newTransactionType == "Withdrawal" || newTransactionType == "withdrawal")
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

                        using (var fileWriter = new StreamWriter("transactions.csv"))
                        {
                            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                            csvWriter.WriteRecords(transactions);
                        }
                    }
                    else
                    {
                        ErrorMessage("Invalid Account Type entered, process canceled.");
                    }
                }
                else
                {
                    ErrorMessage("Invalid Transaction Type Entered, process canceled.");
                }
            }
        }
    }
}

