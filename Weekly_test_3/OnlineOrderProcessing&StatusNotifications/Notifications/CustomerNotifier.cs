
using System; 
using OnlineOrderApp.Enums; 
using OnlineOrderApp.Models; 

namespace OnlineOrderApp.Notifications{

    public class CustomerNotifier // Declares the CustomerNotifier class
    { 

        #region Public Methods // This region contains all public methods of the CustomerNotifier class

        /// <summary>
        /// Sends a notification to the customer about the order status change.
        /// </summary>
        /// <param name="order">The order whose status changed.</param>
        /// <param name="oldStatus">The previous status of the order.</param>
        /// <param name="newStatus">The new status of the order.</param>
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus) // Notifies customer of status change
        { 
            Console.WriteLine($"[Customer] Order {order.OrderId} moved from {oldStatus} to {newStatus}"); // Prints notification to console
        } 

        #endregion
    } 
} 
