using System;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents the base class for all employees.
    /// </summary>
    public abstract class Employee
    {
        #region Properties

        /// <summary>
        /// Gets the unique employee ID.
        /// </summary>
        public int EmployeeId { get; }

        /// <summary>
        /// Gets the employee name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the employee type.
        /// </summary>
        public string EmployeeType { get; protected set; }

        /// <summary>
        /// Gets the base salary or rate.
        /// </summary>
        public decimal BaseSalary { get; protected set; }

        /// <summary>
        /// Gets the number of working days.
        /// </summary>
        public int WorkingDays { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the employee with common details.
        /// </summary>
        protected Employee(int id, string name, decimal baseSalary, int workingDays)
        {
            if (baseSalary < 0)
                throw new ArgumentException("Salary cannot be negative");

            if (workingDays < 0 || workingDays > 31)
                throw new ArgumentException("Working days must be between 0 and 31");

            EmployeeId = id;
            Name = name;
            BaseSalary = baseSalary;
            WorkingDays = workingDays;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates salary using runtime polymorphism.
        /// </summary>
        public abstract PaySlip CalculateSalary();

        #endregion
    }
}
