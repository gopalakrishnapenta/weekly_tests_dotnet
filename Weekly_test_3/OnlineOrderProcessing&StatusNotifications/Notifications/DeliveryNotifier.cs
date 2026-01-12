
using System; 
using OnlineOrderApp.Models; 
using OnlineOrderApp.Enums; 

namespace OnlineOrderApp.Notifications {
    /// <summary>
    /// Notifies the delivery team when an order is ready for delivery.
    /// </summary>
    public class DeliveryNotifier // Declares the DeliveryNotifier class
    {

        #region Public Methods // This region contains all public methods of the DeliveryNotifier class

        /// <summary>
        /// Sends a notification to the delivery team when the order is shipped.
        /// </summary>
        /// <param name="order">The order whose status changed.</param>
        /// <param name="oldStatus">The previous status of the order.</param>
        /// <param name="newStatus">The new status of the order.</param>
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus) // Notifies delivery team of status change
        {
            if (newStatus == OrderStatus.Shipped) // Checks if the new status is Shipped
            { 
                Console.WriteLine($"[Delivery Team] Order {order.OrderId} is ready for delivery"); // Prints notification to console
            } 
        }

        #endregion
    } 
} 
