using System;
using System.Collections.Generic;
using System.Linq;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Generates payroll summary reports.
    /// </summary>
    public static class PayrollReportService
    {
        #region Reporting Methods

        /// <summary>
        /// Prints payroll summary to the console.
        /// </summary>
        public static void PrintSummary(List<PaySlip> payslips)
        {
            Console.WriteLine("\n===== PAYROLL SUMMARY =====");

            Console.WriteLine($"Total Employees Processed: {payslips.Count}");
            Console.WriteLine($"Total Payout: {payslips.Sum(p => p.NetSalary)}");

            var grouped = payslips.GroupBy(p => p.EmployeeType);
            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} Count: {group.Count()}");
            }

            var highestPaid = payslips.OrderByDescending(p => p.NetSalary).First();
            Console.WriteLine($"Highest Paid Employee: {highestPaid.EmployeeName} ({highestPaid.NetSalary})");
        }

        #endregion
    }
}
