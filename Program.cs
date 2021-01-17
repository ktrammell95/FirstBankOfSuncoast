using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{

    class Transaction
    {
        public string Account { get; set; }
        public string TransactionType { get; set; }
        public int TransactionValue { get; set; }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var transactions = new List<Transaction>()
            {
              new Transaction() {
                Account = "Savings",
                TransactionType = "Deposit",
                TransactionValue = 25,
              },
              new Transaction() {
                Account = "Checking",
                TransactionType = "Deposit",
                TransactionValue = 10,
              },
              new Transaction() {
                Account = "Savings",
                TransactionType = "Deposit",
                TransactionValue = 25,
              },
              new Transaction() {
                Account = "Savings",
                TransactionType = "Withdrawal",
                TransactionValue = 5,
              },
              new Transaction() {
                Account = "Checking",
                TransactionType = "Withdrawal",
                TransactionValue = 20,
              },

            };
        }
    }
}
