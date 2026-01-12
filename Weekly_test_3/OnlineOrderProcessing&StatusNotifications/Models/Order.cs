using System; 
using System.Collections.Generic; 
using OnlineOrderApp.Enums; 


namespace OnlineOrderApp.Models 
{
    /// <summary>
    /// Represents a customer's order, including items, status, and history.
    /// </summary>
    public class Order // Declares the Order class
    { 

        #region Fields // This region contains all private fields of the Order class

    private List<OrderItem> items = new List<OrderItem>(); // Stores the list of items in the order
    private List<OrderHistory> history = new List<OrderHistory>(); // Stores the history of status changes for the order
    private List<string> logs = new List<string>(); // Stores logs for the order
    private static List<string> staticLogs = new List<string> { "Order system started.", "Static log: System initialized." };
    /// <summary>
    /// Gets the static logs for the order system.
    /// </summary>
    public static IReadOnlyList<string> StaticLogs => staticLogs;

        #endregion

        #region Properties // This region contains all properties of the Order class

        /// <summary>
        /// Gets the unique identifier for the order.
        /// </summary>
        public int OrderId { get; } // Property to store the order's unique ID

        /// <summary>
        /// Gets the customer who placed the order.
        /// </summary>
        public Customer Customer { get; } // Property to store the customer who placed the order

        /// <summary>
        /// Gets the current status of the order.
        /// </summary>
        public OrderStatus CurrentStatus { get; private set; } // Property to store the current status of the order

        /// <summary>
        /// Gets the list of items in the order as a read-only list.
        /// </summary>
        public IReadOnlyList<OrderItem> Items => items; // Exposes the items list as a read-only property

        /// <summary>
        /// Gets the history of status changes for the order as a read-only list.
        /// </summary>
        public IReadOnlyList<OrderHistory> History => history; // Exposes the history list as a read-only property

        /// <summary>
        /// Gets the logs for the order as a read-only list.
        /// </summary>
        public IReadOnlyList<string> Logs => logs;

        #endregion

        #region Fields - Delegates and Events // This region contains delegates and events for notifications

        /// <summary>
        /// Delegate for status change notifications.
        /// </summary>
        public Action<Order, OrderStatus, OrderStatus> StatusChanged; // Delegate to notify listeners when the order status changes

        #endregion

        #region Constructors // This region contains all constructors for the Order class

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class with the specified order ID and customer.
        /// </summary>
        /// <param name="orderId">The unique identifier for the order.</param>
        /// <param name="customer">The customer who placed the order.</param>
        public Order(int orderId, Customer customer) // Constructor that sets the order's ID and customer
        { 
            OrderId = orderId; // Assigns the provided orderId to the OrderId property
            Customer = customer; // Assigns the provided customer to the Customer property
            CurrentStatus = OrderStatus.Created; // Sets the initial status of the order to Created
        } 

        #endregion

        #region Public Methods // This region contains all public methods of the Order class

        /// <summary>
        /// Adds a product and its quantity to the order.
        /// </summary>
        /// <param name="product">The product to add to the order.</param>
        /// <param name="quantity">The quantity of the product to add.</param>
        public void AddProduct(Product product, int quantity) // Adds a product and its quantity to the order
        { 
            items.Add(new OrderItem(product, quantity)); // Creates a new OrderItem and adds it to the items list
            string logMsg = $"Added {quantity} x {product.Name} (ID: {product.Id}) to order.";
            logs.Add(logMsg);
            staticLogs.Add($"[Dynamic] {logMsg}");
        } 

        /// <summary>
        /// Calculates the total amount for the order, including tax.
        /// </summary>
        /// <returns>The total amount for the order, including tax.</returns>
        public decimal GetTotalAmount() // Calculates the total amount for the order, including tax
        { 
            decimal total = 0; // Initializes the total amount to zero

            foreach (var item in items) // Loops through each item in the order
                total += item.TotalPrice(); // Adds the total price of each item to the total amount

            decimal tax = total * 0.18m; // Calculates 18% tax on the total amount
            return total + tax; // Returns the total amount including tax
        } 

        /// <summary>
        /// Updates the status of the order and records the change in history.
        /// </summary>
        /// <param name="newStatus">The new status to set for the order.</param>
        public void UpdateStatus(OrderStatus newStatus) // Updates the status of the order
        { 
            CheckStatusRules(newStatus); // Checks if the status change is allowed according to business rules

            OrderStatus oldStatus = CurrentStatus; // Stores the old status before changing
            CurrentStatus = newStatus; // Updates the order's status to the new status

            history.Add(new OrderHistory(oldStatus, newStatus)); // Adds a new entry to the history list for this status change

            StatusChanged?.Invoke(this, oldStatus, newStatus); // Notifies any listeners that the status has changed
            string logMsg = $"Order status changed from {oldStatus} to {newStatus}.";
            logs.Add(logMsg);
            staticLogs.Add($"[Dynamic] {logMsg}");
        } 

        #endregion

        #region Private Methods // This region contains all private methods of the Order class

        /// <summary>
        /// Checks if the status change is valid according to business rules.
        /// </summary>
        /// <param name="newStatus">The new status to validate.</param>
        private void CheckStatusRules(OrderStatus newStatus) // Checks if the status change is valid
        { 
            if (CurrentStatus == OrderStatus.Cancelled) // Checks if the current status is Cancelled
                throw new Exception("Order is cancelled. No further changes allowed."); // Throws an exception if the order is cancelled

            if (newStatus == OrderStatus.Shipped && CurrentStatus != OrderStatus.Packed) // Checks if trying to ship before packing
                throw new Exception("Order must be packed before shipping."); // Throws an exception if the order is not packed before shipping

            if (newStatus == OrderStatus.Delivered && CurrentStatus != OrderStatus.Shipped) // Checks if trying to deliver before shipping
                throw new Exception("Order must be shipped before delivery."); // Throws an exception if the order is not shipped before delivery
        } 

        #endregion
    } 
} 
