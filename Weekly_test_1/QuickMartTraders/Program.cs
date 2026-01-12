using System;
namespace QuickMartTraders
{
    class Program
    {
        /// <summary>
        /// Application entry point.
        /// Displays menu and controls program flow.
        /// </summary>
        static void Main(string[] args)
        {
            TransactionService service = new TransactionService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        service.CreateTransaction();
                        break;

                    case "2":
                        service.ViewLastTransaction();
                        break;

                    case "3":
                        service.Recalculate();
                        break;

                    case "4":
                        Console.WriteLine("Thank you. Application closed normally.");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select between 1 and 4.");
                        break;
                }
            }
        }
    }
}
