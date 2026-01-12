using System;
using System.Collections.Generic;
using OnlineOrderApp.Enums;
using OnlineOrderApp.Models;
using OnlineOrderApp.Notifications;
using OnlineOrderApp.Services;

namespace OnlineOrderApp
{
    /// <summary>
    /// The main entry point for the order processing application.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Product catalog
            var products = new Dictionary<int, Product>
            {
                {1, new Product(1, "Laptop", 50000)},
                {2, new Product(2, "Mouse", 500)},
                {3, new Product(3, "Keyboard", 1500)}
            };

            Console.WriteLine("=== Online Order Application ===");

            // Customer input
            Console.Write("Enter Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            var customer = new Customer(customerId, customerName);
            var order = new Order(101, customer);

            // Notifications
            var customerNotifier = new CustomerNotifier();
            var deliveryNotifier = new DeliveryNotifier();

            order.StatusChanged += customerNotifier.Notify;
            order.StatusChanged += deliveryNotifier.Notify;

            // Product selection loop
            while (true)
            {
                Console.WriteLine("\nAvailable Products:");
                foreach (var product in products.Values)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - ₹{product.Price}");
                }

                Console.Write("Enter Product Id to add (0 to finish): ");
                int productId = int.Parse(Console.ReadLine());

                if (productId == 0)
                    break;

                if (!products.ContainsKey(productId))
                {
                    Console.WriteLine("Invalid product id!");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                order.AddProduct(products[productId], quantity);
                Console.WriteLine("Product added to order.");
            }

            // Order status flow
            order.UpdateStatus(OrderStatus.Paid);
            order.UpdateStatus(OrderStatus.Packed);
            order.UpdateStatus(OrderStatus.Shipped);
            order.UpdateStatus(OrderStatus.Delivered);

            // Print order
            var printer = new OrderPrinter();
            printer.Print(order);

            Console.WriteLine("\nOrder completed successfully!");
            Console.ReadLine();
        }
    }
}
