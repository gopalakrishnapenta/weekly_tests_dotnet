using MediSureClinic;
using System;
namespace MediSureClinic
{
    /// <summary>
    /// Application entry point.
    /// Displays menu options and routes user input to billing services.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that starts the application
        /// and controls the menu-driven execution flow.
        /// </summary>
        static void Main()
        {
            BillingService service = new BillingService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n================ MediSure Clinic Billing ================");
                Console.WriteLine("1. Create New Bill");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            service.CreateBill();
                            break;

                        case "2":
                            service.ViewBill();
                            break;

                        case "3":
                            service.ClearBill();
                            break;

                        case "4":
                            Console.WriteLine("Thank you. Application closed normally.");
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please choose between 1 and 4.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Input Error: {ex.Message}");
                }
            }
        }
    }
}
