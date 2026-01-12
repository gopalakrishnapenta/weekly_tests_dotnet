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
            var products = GetProductCatalog();
            Console.WriteLine("=== Online Order Application ===");

            var customer = GetCustomerInput();
            var order = new Order(101, customer);
            RegisterNotifications(order);
            SelectProducts(order, products);
            ProcessOrder(order);
            PrintOrderAndLogs(order);
            Console.ReadLine();
        }

        static Dictionary<int, Product> GetProductCatalog()
        {
            return new Dictionary<int, Product>
            {
                {1, new Product(1, "Laptop", 50000)},
                {2, new Product(2, "Mouse", 500)},
                {3, new Product(3, "Keyboard", 1500)}
            };
        }

        static Customer GetCustomerInput()
        {
            Console.Write("Enter Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            return new Customer(customerId, customerName);
        }

        static void RegisterNotifications(Order order)
        {
            var customerNotifier = new CustomerNotifier();
            var deliveryNotifier = new DeliveryNotifier();
            order.StatusChanged += customerNotifier.Notify;
            order.StatusChanged += deliveryNotifier.Notify;
        }

        static void SelectProducts(Order order, Dictionary<int, Product> products)
        {
            while (true)
            {
                Console.WriteLine("\nAvailable Products:");
                foreach (var product in products.Values)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - ₹{product.Price}");
                }
                Console.Write("Enter Product Id to add (0 to finish): ");
                if (!int.TryParse(Console.ReadLine(), out int productId) || productId < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (productId == 0)
                    break;
                if (!products.ContainsKey(productId))
                {
                    Console.WriteLine("Invalid product id!");
                    continue;
                }
                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity!");
                    continue;
                }
                order.AddProduct(products[productId], quantity);
                Console.WriteLine("Product added to order.");
            }
        }

        static void ProcessOrder(Order order)
        {
            order.UpdateStatus(OrderStatus.Paid);
            order.UpdateStatus(OrderStatus.Packed);
            order.UpdateStatus(OrderStatus.Shipped);
            order.UpdateStatus(OrderStatus.Delivered);
        }

        static void PrintOrderAndLogs(Order order)
        {
            var printer = new OrderPrinter();
            printer.Print(order);
            Console.WriteLine("\nOrder completed successfully!");
            Console.WriteLine("\n===== STATIC ORDER LOG SUMMARY =====");
            foreach (var log in Order.StaticLogs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("\n===== DYNAMIC ORDER LOG SUMMARY =====");
            foreach (var log in order.Logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
