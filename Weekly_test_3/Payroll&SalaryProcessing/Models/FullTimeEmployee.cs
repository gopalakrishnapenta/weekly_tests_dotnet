namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents a full-time employee.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Constructors

        /// <summary>
        /// Initializes a full-time employee.
        /// </summary>
        public FullTimeEmployee(int id, string name, decimal monthlySalary, int workingDays)
            : base(id, name, monthlySalary, workingDays)
        {
            EmployeeType = "Full-Time";
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates salary for a full-time employee.
        /// </summary>
        public override PaySlip CalculateSalary()
        {
            decimal gross = BaseSalary;
            decimal tax = gross * 0.10m;
            decimal insurance = gross * 0.05m;
            decimal deductions = tax + insurance;
            decimal net = gross - deductions;

            return new PaySlip(EmployeeId, Name, EmployeeType, gross, deductions, net);
        }

        #endregion
    }
}
