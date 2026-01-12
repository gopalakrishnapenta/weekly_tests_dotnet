using System;
using System.Collections.Generic;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Responsible for processing payroll.
    /// </summary>
    public class PayrollProcessor
    {
        #region Delegates

        /// <summary>
        /// Delegate invoked after salary is processed.
        /// </summary>
        public Action<PaySlip> SalaryProcessed;

        #endregion

        #region Public Methods

        /// <summary>
        /// Processes payroll for all employees.
        /// </summary>
        public List<PaySlip> ProcessPayroll(List<Employee> employees)
        {
            var payslips = new List<PaySlip>();

            foreach (var employee in employees)
            {
                try
                {
                    PaySlip slip = employee.CalculateSalary();
                    payslips.Add(slip);

                    SalaryProcessed?.Invoke(slip);

                    Console.WriteLine(
                        $"Processed: {slip.EmployeeName} | Gross: {slip.GrossSalary} | Net: {slip.NetSalary}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing employee {employee.Name}: {ex.Message}");
                }
            }

            return payslips;
        }

        #endregion
    }
}
