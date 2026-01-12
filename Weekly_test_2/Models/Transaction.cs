using System;
using DigitalPettyCashLedger.Interfaces;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Represents a base financial transaction.
    /// This class provides common properties for all transaction types.
    /// </summary>
    public abstract class Transaction : IReportable
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date on which the transaction occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Monetary value of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Additional information describing the transaction.
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Abstract Members

        /// <summary>
        /// Provides a formatted summary of the transaction.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <returns>Transaction summary</returns>
        public abstract string GetSummary();

        #endregion
    }
}
