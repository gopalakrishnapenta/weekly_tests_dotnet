namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents a contract employee.
    /// </summary>
    public class ContractEmployee : Employee
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ContractEmployee class.
        /// </summary>
        public ContractEmployee(int id, string name, decimal dailyRate, int workingDays)
            : base(id, name, dailyRate, workingDays)
        {
            EmployeeType = "Contract";
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates salary for a contract employee.
        /// </summary>
        public override PaySlip CalculateSalary()
        {
            decimal gross = BaseSalary * WorkingDays;
            decimal deductions = gross * 0.05m;
            decimal net = gross - deductions;

            return new PaySlip(EmployeeId, Name, EmployeeType, gross, deductions, net);
        }

        #endregion
    }
}
