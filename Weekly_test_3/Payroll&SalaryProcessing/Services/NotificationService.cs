using System;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Handles payroll notifications.
    /// </summary>
    public static class NotificationService
    {
        #region Notification Methods

        /// <summary>
        /// Notifies HR after salary processing.
        /// </summary>
        public static void NotifyHR(PaySlip slip)
        {
            Console.WriteLine($"[HR] Salary processed for {slip.EmployeeName}");
        }

        /// <summary>
        /// Notifies Finance after salary processing.
        /// </summary>
        public static void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine($"[Finance] Payment initiated for {slip.EmployeeName}");
        }

        #endregion
    }
}
