using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;

namespace PayrollSystem
{
    /// <summary>
    /// Entry point of the Payroll System application.
    /// </summary>
    class Program
    {
        static void Main()
        {
            #region Sample Data Initialization

            // Hardcoded employee data as per assignment requirement
            var employees = new List<Employee>
            {
                new FullTimeEmployee(1, "Ravi", 50000, 30),
                new FullTimeEmployee(2, "Anita", 60000, 30),
                new ContractEmployee(3, "Suresh", 1500, 20),
                new ContractEmployee(4, "Meena", 1200, 22),
                new FullTimeEmployee(5, "John", 70000, 30),
                new ContractEmployee(6, "Kiran", 1000, 25)
            };

            Console.WriteLine("6 employees added successfully.\n");

            #endregion

            #region Payroll Processing

            var payrollProcessor = new PayrollProcessor();

            // Multicast delegate subscriptions
            payrollProcessor.SalaryProcessed += NotificationService.NotifyHR;
            payrollProcessor.SalaryProcessed += NotificationService.NotifyFinance;

            List<PaySlip> payslips = payrollProcessor.ProcessPayroll(employees);

            #endregion

            #region Reporting

            PayrollReportService.PrintSummary(payslips);

            #endregion

            
        }
    }
}
