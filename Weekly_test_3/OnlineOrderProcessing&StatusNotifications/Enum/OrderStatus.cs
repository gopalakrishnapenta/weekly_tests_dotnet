
namespace OnlineOrderApp.Enums
{
    /// <summary>
    /// Represents the different statuses an order can have during its lifecycle.
    /// </summary>
    public enum OrderStatus // Declares the OrderStatus enum
    { // Start of OrderStatus enum block
        Created, // The order has been created but not yet processed
        Paid, // The order has been paid for by the customer
        Packed, // The order has been packed and is ready for shipment
        Shipped, // The order has been shipped to the customer
        Delivered, // The order has been delivered to the customer
        Cancelled // The order has been cancelled
    } 
} 
