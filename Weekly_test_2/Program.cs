using System;
using System.Collections.Generic;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Services;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Application entry point for the Digital Petty Cash Ledger System.
    /// Demonstrates income tracking, expense recording, and balance calculation.
    /// </summary>
    class Program
    {
        static void Main()
        {
            #region Income Ledger Initialization
            /// <summary>
            /// Initializes the income ledger and adds initial income transactions.
            /// </summary>
            /// <typeparam name="IncomeTransaction"></typeparam>
            /// <returns></returns>
            var incomeLedger = new Ledger<IncomeTransaction>();
            incomeLedger.AddEntry(new IncomeTransaction
            {
                Id = 1,
                Date = DateTime.Today,
                Amount = 500,
                Source = "Main Cash",
                Description = "Petty cash replenishment"
            });

            #endregion

            #region Expense Ledger Initialization
            /// <summary>
            /// Initializes the expense ledger and adds initial expense transactions.
            /// </summary>
            /// <typeparam name="ExpenseTransaction"></typeparam>
            /// <returns></returns>
            var expenseLedger = new Ledger<ExpenseTransaction>();
            expenseLedger.AddEntry(new ExpenseTransaction
            {
                Id = 2,
                Date = DateTime.Today,
                Amount = 50,
                Category = "Stationery",
                Description = "Office supplies"
            });

            /// <summary>
            /// Adds an expense transaction to the ledger.
            /// </summary>
            expenseLedger.AddEntry(new ExpenseTransaction
            {
                
                Id = 3,
                Date = DateTime.Today,
                Amount = 70,
                Category = "Food",
                Description = "Team snacks"
            });

            #endregion

            #region Financial Calculations
            /// <summary>
            /// Calculates and displays the total income, total expenses, and net balance.
            /// </summary>
            decimal totalIncome = incomeLedger.CalculateTotal();
            decimal totalExpense = expenseLedger.CalculateTotal();
            decimal netBalance = totalIncome - totalExpense;

            Console.WriteLine($"Total Income  : ₹{totalIncome}");
            Console.WriteLine($"Total Expense : ₹{totalExpense}");
            Console.WriteLine($"Net Balance   : ₹{netBalance}\n");

            #endregion

            #region Polymorphism Demonstration

            var allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAllTransactions());
            allTransactions.AddRange(expenseLedger.GetAllTransactions());

            Console.WriteLine("Transaction Summary:");
            foreach (var transaction in allTransactions)
            {
                Console.WriteLine(transaction.GetSummary());
            }

            #endregion


        }
    }
}
