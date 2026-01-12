
using System; 
using System.Collections.Generic; 
using OnlineOrderApp.Enums; 
using OnlineOrderApp.Models; 
using OnlineOrderApp.Notifications;
using OnlineOrderApp.Services; 

namespace OnlineOrderApp {
    /// <summary>
    /// The main entry point for the order processing application.
    /// </summary>
    class Program // Declares the Program class
    { 

        #region Public Methods // This region contains all public methods of the Program class

        /// <summary>
        /// The main method where the application starts execution.
        /// </summary>
        static void Main() // Main method, application entry point
        { 
            // Products
            var products = new Dictionary<int, Product> // Creates a dictionary to store products with their IDs as keys
            {
                {1, new Product(1, "Laptop", 50000)}, // Adds a Laptop product with ID 1 and price 50000
                {2, new Product(2, "Mouse", 500)}, // Adds a Mouse product with ID 2 and price 500
                {3, new Product(3, "Keyboard", 1500)} // Adds a Keyboard product with ID 3 and price 1500
            };

            // Customers
            var customer = new Customer(1, "Gopal"); // Creates a customer with ID 1 and name "Gopal"

            // Order
            var order = new Order(101, customer); // Creates a new order with ID 101 for the customer
            order.AddProduct(products[1], 1); // Adds 1 Laptop to the order
            order.AddProduct(products[2], 2); // Adds 2 Mice to the order

            // Notifications
            var customerNotifier = new CustomerNotifier(); // Creates a notifier for the customer
            var deliveryNotifier = new DeliveryNotifier(); // Creates a notifier for the delivery team

            order.StatusChanged += customerNotifier.Notify; // Subscribes customer notifier to status changes
            order.StatusChanged += deliveryNotifier.Notify; // Subscribes delivery notifier to status changes

            // Status flow
            order.UpdateStatus(OrderStatus.Paid); // Updates status to Paid
            order.UpdateStatus(OrderStatus.Packed); // Updates status to Packed
            order.UpdateStatus(OrderStatus.Shipped); // Updates status to Shipped
            order.UpdateStatus(OrderStatus.Delivered); // Updates status to Delivered

            // Print Order
            var printer = new OrderPrinter(); // Creates an order printer
            printer.Print(order); // Prints the order details

            //Console.ReadLine(); // Waits for user input before closing the application
        } 

        #endregion
    } 
} 