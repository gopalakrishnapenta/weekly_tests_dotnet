using System;
using System.Collections.Generic;
using System.Text;

namespace MediSureClinic
{
    /// <summary>
    /// Represents a patient's billing details in the MedSure Clinic system.
    /// Responsible for calculating the total bill, applicable discounts,
    /// and the final payable amount.
    /// </summary>
    public class PatientBill
    {
        // Unique identifier for the bill.
        public string BillId { get; set; }

        // Name of the patient.
        public string PatientName { get; set; }

        // Indicates whether the patient has medical insurance.
        public bool HasInsurance { get; set; }

        // Fee charged for doctor consultation.
        public decimal ConsultationFee { get; set; }
        
        // Charges for laboratory tests.
        public decimal LabCharges { get; set; }

        // Charges for prescribed medicines.
        public decimal MedicineCharges { get; set; }

        // Total amount before applying any discounts.
        // Calculated internally.
        public decimal GrossAmount { get; private set; }

        // Discount applied based on insurance availability.
        // Calculated internally.
        public decimal DiscountAmount { get; private set; }

        // Final amount the patient needs to pay after discount.
        // Calculated internally.
        public decimal FinalPayable { get; private set; }

        // Calculates the gross bill amount, insurance discount,
        // and final payable amount.
        public void Calculate()
        {
            // Calculate total bill before discount
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            // Apply 10% discount if the patient has insurance
            if (HasInsurance)
                DiscountAmount = GrossAmount * 0.10m;
            else
                DiscountAmount = 0;

            // Calculate final payable amount after discount
            FinalPayable = GrossAmount - DiscountAmount;
        }
    }
}
