
using System; 
using OnlineOrderApp.Models; 

namespace OnlineOrderApp.Services {
    /// <summary>
    /// Provides functionality to print order details to the console.
    /// </summary>
    public class OrderPrinter // Declares the OrderPrinter class
    { 

        #region Public Methods // This region contains all public methods of the OrderPrinter class

        /// <summary>
        /// Prints the details of the specified order to the console.
        /// </summary>
        /// <param name="order">The order to print.</param>
        public void Print(Order order) // Prints order details
        { 
            Console.WriteLine("\n===== ORDER DETAILS ====="); // Prints a header for order details
            Console.WriteLine($"Order Id : {order.OrderId}"); // Prints the order ID
            Console.WriteLine($"Customer : {order.Customer.Name}"); // Prints the customer name
            Console.WriteLine($"Status   : {order.CurrentStatus}"); // Prints the current order status

            Console.WriteLine("\nItems:"); // Prints a header for the items section
            foreach (var item in order.Items) // Loops through each item in the order
            { 
                Console.WriteLine($"- {item.Product.Name} x {item.Quantity}"); // Prints the product name and quantity
            } 

            Console.WriteLine($"\nTotal Amount : {order.GetTotalAmount()}"); // Prints the total amount for the order

            Console.WriteLine("\nStatus History:"); // Prints a header for the status history section
            foreach (var h in order.History) // Loops through each status change in the order's history
            { 
                Console.WriteLine($"{h.ChangedOn} : {h.FromStatus} → {h.ToStatus}"); // Prints the date and status transition
            } 
        } 

        #endregion
    } 
} 