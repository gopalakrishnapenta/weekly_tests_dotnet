using System;
namespace QuickMartTraders
{
    // Handles transaction creation, calculation, and display
    /// <summary>
    /// Provides functionality to create, calculate, and display sales transactions, including profit or loss
    /// calculations for the most recent transaction.
    /// </summary>
    public class TransactionService
    {
        // Static memory storage (only ONE transaction allowed)
        public static SaleTransaction LastTransaction;
        public static bool HasLastTransaction = false;
        // Creates a new transaction and stores it
        public void CreateTransaction()
        {
            SaleTransaction txn = new SaleTransaction();

            Console.Write("Enter Invoice No: ");
            txn.InvoiceNo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(txn.InvoiceNo))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }

            Console.Write("Enter Customer Name: ");
            txn.CustomerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            txn.ItemName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }
            txn.Quantity = qty;

            Console.Write("Enter Purchase Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal purchase) || purchase <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than zero.");
                return;
            }
            txn.PurchaseAmount = purchase;

            Console.Write("Enter Selling Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal selling) || selling < 0)
            {
                Console.WriteLine("Selling Amount must be zero or greater.");
                return;
            }
            txn.SellingAmount = selling;

            CalculateProfitLoss(txn);

            LastTransaction = txn;
            HasLastTransaction = true;

            Console.WriteLine("\nTransaction saved successfully.");
            PrintCalculation(txn);
            Console.WriteLine("------------------------------------------------------");
        }

        // Displays the last transaction
        public void ViewLastTransaction()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            SaleTransaction t = LastTransaction;

            Console.WriteLine("\n-------------- Last Transaction --------------");
            Console.WriteLine($"InvoiceNo: {t.InvoiceNo}");
            Console.WriteLine($"Customer: {t.CustomerName}");
            Console.WriteLine($"Item: {t.ItemName}");
            Console.WriteLine($"Quantity: {t.Quantity}");
            Console.WriteLine($"Purchase Amount: {t.PurchaseAmount:F2}");
            Console.WriteLine($"Selling Amount: {t.SellingAmount:F2}");
            Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
            Console.WriteLine("--------------------------------------------");
        }

        // Recalculates profit or loss for last transaction
        public void Recalculate()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            CalculateProfitLoss(LastTransaction);
            PrintCalculation(LastTransaction);
        }

        // Core calculation logic
        private void CalculateProfitLoss(SaleTransaction txn)
        {
            if (txn.SellingAmount > txn.PurchaseAmount)
            {
                txn.ProfitOrLossStatus = "PROFIT";
                txn.ProfitOrLossAmount = txn.SellingAmount - txn.PurchaseAmount;
            }
            else if (txn.SellingAmount < txn.PurchaseAmount)
            {
                txn.ProfitOrLossStatus = "LOSS";
                txn.ProfitOrLossAmount = txn.PurchaseAmount - txn.SellingAmount;
            }
            else
            {
                txn.ProfitOrLossStatus = "BREAK-EVEN";
                txn.ProfitOrLossAmount = 0;
            }

            txn.ProfitMarginPercent =
                (txn.ProfitOrLossAmount / txn.PurchaseAmount) * 100;
        }

        // Prints calculation output
        private void PrintCalculation(SaleTransaction txn)
        {
            Console.WriteLine($"Status: {txn.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {txn.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {txn.ProfitMarginPercent:F2}");
        }
    }
}
