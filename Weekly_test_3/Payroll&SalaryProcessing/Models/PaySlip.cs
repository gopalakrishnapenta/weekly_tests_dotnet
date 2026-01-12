namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents salary details for an employee.
    /// </summary>
    public class PaySlip
    {
        #region Properties

        /// <summary>
        /// Gets the employee ID.
        /// </summary>
        public int EmployeeId { get; }

        /// <summary>
        /// Gets the employee name.
        /// </summary>
        public string EmployeeName { get; }

        /// <summary>
        /// Gets the employee type.
        /// </summary>
        public string EmployeeType { get; }

        /// <summary>
        /// Gets the gross salary.
        /// </summary>
        public decimal GrossSalary { get; }

        /// <summary>
        /// Gets the total deductions.
        /// </summary>
        public decimal Deductions { get; }

        /// <summary>
        /// Gets the net salary.
        /// </summary>
        public decimal NetSalary { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PaySlip class.
        /// </summary>
        public PaySlip(int id, string name, string type, decimal gross, decimal deductions, decimal net)
        {
            EmployeeId = id;
            EmployeeName = name;
            EmployeeType = type;
            GrossSalary = gross;
            Deductions = deductions;
            NetSalary = net;
        }

        #endregion
    }
}
