using MediSureClinic;
using System;
namespace MediSureClinic
{
    /// <summary>
    /// Handles patient billing operations such as bill creation,
    /// viewing the last bill, and clearing stored billing data.
    /// </summary>
    public class BillingService
    {
        /// <summary>
        /// Stores the most recently created patient bill in memory.
        /// </summary>
        public static PatientBill LastBill;

        /// <summary>
        /// Indicates whether a bill currently exists.
        /// </summary>
        public static bool HasLastBill;

        /// <summary>
        /// Captures patient details from the user,
        /// calculates billing amounts, and stores the bill.
        /// </summary>
        public void CreateBill()
        {
            PatientBill bill = new PatientBill
            {
                BillId = GetRequiredInput("Enter Bill Id: "),
                PatientName = GetRequiredInput("Enter Patient Name: "),
                HasInsurance = GetInsuranceStatus(),
                ConsultationFee = GetConsultationFee(),
                LabCharges = GetChargeAmount("Enter Lab Charges: "),
                MedicineCharges = GetChargeAmount("Enter Medicine Charges: ")
            };

            bill.Calculate();

            LastBill = bill;
            HasLastBill = true;

            Console.WriteLine("\nBill created successfully.");
            PrintBillingSummary(bill);
        }

        /// <summary>
        /// Displays the most recently created bill.
        /// </summary>
        public void ViewBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }

            Console.WriteLine("\n----------- Last Bill -----------");
            Console.WriteLine($"Bill Id          : {LastBill.BillId}");
            Console.WriteLine($"Patient Name     : {LastBill.PatientName}");
            Console.WriteLine($"Insured          : {(LastBill.HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Consultation Fee : {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges      : {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges : {LastBill.MedicineCharges:F2}");

            PrintBillingSummary(LastBill);

            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// Clears the stored billing information from memory.
        /// </summary>
        public void ClearBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
        }

        // ethods

        /// <summary>
        /// Gets a mandatory input value from the user.
        /// </summary>
        private string GetRequiredInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("This field is required.");

            return input.Trim();
        }

        /// <summary>
        /// Determines whether the patient has insurance coverage.
        /// </summary>
        private bool GetInsuranceStatus()
        {
            Console.Write("Is the patient insured? (Y/N): ");
            return Console.ReadLine().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the consultation fee entered by the user.
        /// </summary>
        /// <summary>
        /// Gets the consultation fee entered by the user.
        /// </summary>
        private decimal GetConsultationFee()
        {
            Console.Write("Enter Consultation Fee: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal value) || value <= 0)
                throw new Exception("Consultation fee must be greater than zero.");

            return value;
        }


        /// <summary>
        /// Gets a charge amount that must be zero or greater.
        /// Used for lab and medicine charges.
        /// </summary>
        private decimal GetChargeAmount(string prompt)
        {
            Console.Write(prompt);

            if (!decimal.TryParse(Console.ReadLine(), out decimal value) || value < 0)
                throw new Exception("Charge amount cannot be negative.");

            return value;
        }


        /// <summary>
        /// Prints calculated billing amounts in a formatted manner.
        /// </summary>
        private void PrintBillingSummary(PatientBill bill)
        {
            Console.WriteLine($"Gross Amount     : {bill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount  : {bill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable    : {bill.FinalPayable:F2}");
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}
