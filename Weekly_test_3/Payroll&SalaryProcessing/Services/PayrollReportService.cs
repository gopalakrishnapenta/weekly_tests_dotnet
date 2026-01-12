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
            Console.WriteLine($"Total Employees: {payslips.Count}");
            Console.WriteLine($"Total Payout: {payslips.Sum(p => p.NetSalary)}");

            int fullTimeCount = payslips.Count(p => p.EmployeeType == "Full-Time");
            int contractCount = payslips.Count(p => p.EmployeeType == "Contract");
            Console.WriteLine($"Full-Time Employees: {fullTimeCount}");
            Console.WriteLine($"Contract Employees: {contractCount}");

            var highestPaid = payslips.OrderByDescending(p => p.NetSalary).First();
            Console.WriteLine($"Highest Paid Employee: {highestPaid.EmployeeName} ({highestPaid.NetSalary})");
        }

        #endregion
    }
}
