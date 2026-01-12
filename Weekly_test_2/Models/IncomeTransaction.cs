using DigitalPettyCashLedger.Models;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Represents an income transaction in the petty cash system.
    /// Typically used for fund replenishments.
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        #region Properties

        /// <summary>
        /// Source from which the income was received
        /// (e.g., Main Cash, Bank Transfer).
        /// </summary>
        public string Source { get; set; }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a formatted summary specific to income transactions.
        /// </summary>
        /// <returns>Income transaction summary</returns>
        public override string GetSummary()
        {
            return $"[INCOME] ₹{Amount} received from {Source} on {Date:d}";
        }

        #endregion
    }
}
