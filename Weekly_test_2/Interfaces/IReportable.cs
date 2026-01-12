namespace DigitalPettyCashLedger.Interfaces
{
    /// <summary>
    /// Defines a contract for reportable entities.
    /// Any implementing class must provide a summary representation.
    /// </summary>
    public interface IReportable
    {
        /// <summary>
        /// Returns a human-readable summary of the object.
        /// </summary>
        /// <returns>Formatted summary string</returns>
        string GetSummary();
    }
}
