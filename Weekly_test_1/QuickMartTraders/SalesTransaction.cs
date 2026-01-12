using System;
namespace QuickMartTraders
{
    // Entity class representing a sales transaction
    public class SaleTransaction
    {
        // Unique invoice number
        public string InvoiceNo { get; set; }
        // Customer name
        public string CustomerName { get; set; }

        // Item name
        public string ItemName { get; set; }

        // Quantity of items sold
        public int Quantity { get; set; }

        // Total purchase amount
        public decimal PurchaseAmount { get; set; }

        // Total selling amount
        public decimal SellingAmount { get; set; }

        // PROFIT / LOSS / BREAK-EVEN
        public string ProfitOrLossStatus { get; set; }

        // Calculated profit or loss amount
        public decimal ProfitOrLossAmount { get; set; }

        // Calculated profit margin percentage
        public decimal ProfitMarginPercent { get; set; }
    }
}
