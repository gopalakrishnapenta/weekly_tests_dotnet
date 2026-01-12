using System;
using System.Collections.Generic;
using System.Linq;
using DigitalPettyCashLedger.Models;

namespace DigitalPettyCashLedger.Services
{
    /// <summary>
    /// Generic ledger class responsible for managing transactions.
    /// Enforces compile-time type safety using generic constraints.
    /// </summary>
    /// <typeparam name="T">Transaction type</typeparam>
    public class Ledger<T> where T : Transaction
    {
        #region Fields

        /// <summary>
        /// Internal in-memory storage for transaction records.
        /// </summary>
        private readonly List<T> transactions = new();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a transaction entry to the ledger.
        /// </summary>
        /// <param name="entry">Transaction to be added</param>
        public void AddEntry(T entry)
        {
            transactions.Add(entry);
        }

        /// <summary>
        /// Retrieves all transactions as a read-only list.
        /// </summary>
        /// <returns>Read-only transaction list</returns>
        public IReadOnlyList<T> GetAllTransactions()
        {
            return transactions.AsReadOnly();
        }

        /// <summary>
        /// Filters transactions based on a specific date.
        /// </summary>
        /// <param name="date">Target date</param>
        /// <returns>Filtered list of transactions</returns>
        public List<T> GetTransactionsByDate(DateTime date)
        {
            return transactions
                .Where(t => t.Date.Date == date.Date)
                .ToList();
        }

        /// <summary>
        /// Calculates the total amount of all transactions in the ledger.
        /// </summary>
        /// <returns>Total transaction amount</returns>
        public decimal CalculateTotal()
        {
            return transactions.Sum(t => t.Amount);
        }

        #endregion
    }
}
