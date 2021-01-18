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
        public int TransactionValue { get; set; }

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
                Console.WriteLine("- View: View All Transactions");
                Console.WriteLine("- Balance: Check Balance");
                Console.WriteLine("- Cancel");
                var newAccountType = Console.ReadLine();

                // Console.WriteLine(newTransactionType);

                if (newAccountType == "Savings" || newAccountType == "savings")
                {
                    newAccountType = "Savings";

                    Console.WriteLine("Would you like to make a Deposit or Withdrawal?");

                    var newTransactionType = Console.ReadLine();

                    if (newTransactionType == "Deposit" || newTransactionType == "deposit")
                    {
                        newTransactionType = "Deposit";

                        Console.WriteLine("Enter a $ amount");
                        var newTransactionValueString = Console.ReadLine();
                        var newTransactionValue = int.Parse(newTransactionValueString);

                        var newTransaction = new Transaction()
                        {
                            AccountType = newAccountType,
                            TransactionType = newTransactionType,
                            TransactionValue = newTransactionValue,
                        };

                        transactions.Add(newTransaction);

                    }
                    if (newTransactionType == "Withdrawal" || newTransactionType == "withdrawal")
                    {
                        newTransactionType = "Withdrawal";
                        Console.WriteLine("Enter a $ amount");
                        var newTransactionValueString = Console.ReadLine();
                        var newTransactionValue = int.Parse(newTransactionValueString);

                        var savingsDepositTransactions = transactions.Where(transactions => transactions.AccountType == "Savings" && transactions.TransactionType == "Deposit");
                        var savingsAddTransactionValues = savingsDepositTransactions.Select(transactions => transactions.TransactionValue);
                        var savingsWithdrawalTransactions = transactions.Where(transactions => transactions.AccountType == "Savings" && transactions.TransactionType == "Withdrawal");
                        var savingsSubtractTransactionValues = savingsWithdrawalTransactions.Select(transactions => transactions.TransactionValue);
                        var savingsAdditions = savingsAddTransactionValues.Sum();
                        var savingSubtractions = savingsSubtractTransactionValues.Sum();
                        var savingsBal = savingsAdditions - savingSubtractions;

                        if (newTransactionValue <= savingsBal)
                        {
                            var newTransaction = new Transaction()
                            {
                                AccountType = newAccountType,
                                TransactionType = newTransactionType,
                                TransactionValue = newTransactionValue,
                            };

                            transactions.Add(newTransaction);
                        }
                        else
                        {
                            Console.WriteLine("There are INSUFFICIENT funds for this request.");

                        }
                    }
                }
                else if (newAccountType == "Checking" || newAccountType == "checking")
                {
                    newAccountType = "Checking";

                    Console.WriteLine("Would you like to make a Deposit or Withdrawal?");

                    var newTransactionType = Console.ReadLine();

                    if (newTransactionType == "Deposit" || newTransactionType == "deposit")
                    {
                        newTransactionType = "Deposit";

                        Console.WriteLine("Enter a $ amount");
                        var newTransactionValueString = Console.ReadLine();
                        var newTransactionValue = int.Parse(newTransactionValueString);

                        var newTransaction = new Transaction()
                        {
                            AccountType = newAccountType,
                            TransactionType = newTransactionType,
                            TransactionValue = newTransactionValue,
                        };

                        transactions.Add(newTransaction);

                    }
                    if (newTransactionType == "Withdrawal" || newTransactionType == "withdrawal")
                    {
                        newTransactionType = "Withdrawal";
                        Console.WriteLine("Enter a $ amount");
                        var newTransactionValueString = Console.ReadLine();
                        var newTransactionValue = int.Parse(newTransactionValueString);

                        var checkingDepositTransactions = transactions.Where(transactions => transactions.AccountType == "Checking" && transactions.TransactionType == "Deposit");
                        var checkingAddTransactionValues = checkingDepositTransactions.Select(transactions => transactions.TransactionValue);
                        var checkingWithdrawalTransactions = transactions.Where(transactions => transactions.AccountType == "Checking" && transactions.TransactionType == "Withdrawal");
                        var checkingSubtractTransactionValues = checkingWithdrawalTransactions.Select(transactions => transactions.TransactionValue);
                        var checkingAdditions = checkingAddTransactionValues.Sum();
                        var checkingSubtractions = checkingSubtractTransactionValues.Sum();
                        var checkingBal = checkingAdditions - checkingSubtractions;

                        if (newTransactionValue <= checkingBal)
                        {
                            var newTransaction = new Transaction()
                            {
                                AccountType = newAccountType,
                                TransactionType = newTransactionType,
                                TransactionValue = newTransactionValue,
                            };

                            transactions.Add(newTransaction);
                        }
                        else
                        {
                            Console.WriteLine("There are INSUFFICIENT funds for this request.");

                        }
                    }
                }
                else if (newAccountType == "View" || newAccountType == "view")
                {
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine($"{transaction.TransactionType} ${transaction.TransactionValue} into {transaction.AccountType} ");
                    };
                    Console.WriteLine();
                    Console.WriteLine("**********");
                    Console.WriteLine();
                }
                else if (newAccountType == "Balance" || newAccountType == "balance")
                {
                    var savingsDepositTransactions = transactions.Where(transactions => transactions.AccountType == "Savings" && transactions.TransactionType == "Deposit");
                    var savingsAddTransactionValues = savingsDepositTransactions.Select(transactions => transactions.TransactionValue);
                    var savingsWithdrawalTransactions = transactions.Where(transactions => transactions.AccountType == "Savings" && transactions.TransactionType == "Withdrawal");
                    var savingsSubtractTransactionValues = savingsWithdrawalTransactions.Select(transactions => transactions.TransactionValue);
                    var savingsAdditions = savingsAddTransactionValues.Sum();
                    var savingSubtractions = savingsSubtractTransactionValues.Sum();
                    var savingsBal = savingsAdditions - savingSubtractions;
                    Console.WriteLine($" Savings Balance: ${savingsBal}");

                    var checkingDepositTransactions = transactions.Where(transactions => transactions.AccountType == "Checking" && transactions.TransactionType == "Deposit");
                    var checkingAddTransactionValues = checkingDepositTransactions.Select(transactions => transactions.TransactionValue);
                    var checkingWithdrawalTransactions = transactions.Where(transactions => transactions.AccountType == "Checking" && transactions.TransactionType == "Withdrawal");
                    var checkingSubtractTransactionValues = checkingWithdrawalTransactions.Select(transactions => transactions.TransactionValue);
                    var checkingAdditions = checkingAddTransactionValues.Sum();
                    var checkingSubtractions = checkingSubtractTransactionValues.Sum();
                    var checkingBal = checkingAdditions - checkingSubtractions;
                    Console.WriteLine($" Checking Balance: ${checkingBal}");


                    Console.WriteLine();
                    Console.WriteLine("**********");
                    Console.WriteLine();
                }
                else if (newAccountType == "Cancel" || newAccountType == "cancel")
                {
                    hasQuit = true;
                    BannerMessage("Have a great day!");
                }
                else
                {
                    ErrorMessage("Invalid Transaction Type Entered, process canceled.");
                }

                using (var fileWriter = new StreamWriter("transactions.csv"))
                {
                    var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(transactions);
                }
            }
        }
    }
}

