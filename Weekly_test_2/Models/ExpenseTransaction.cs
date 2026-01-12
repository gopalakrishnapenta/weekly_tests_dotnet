using DigitalPettyCashLedger.Models;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Represents an expense transaction in the petty cash system.
    /// Used for tracking daily operational expenses.
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        #region Properties

        /// <summary>
        /// Category under which the expense falls
        /// (e.g., Stationery, Food, Travel).
        /// </summary>
        public string Category { get; set; }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a formatted summary specific to expense transactions.
        /// </summary>
        /// <returns>Expense transaction summary</returns>
        public override string GetSummary()
        {
            return $"[EXPENSE] ₹{Amount} spent on {Category} ({Description}) on {Date:d}";
        }

        #endregion
    }
}
