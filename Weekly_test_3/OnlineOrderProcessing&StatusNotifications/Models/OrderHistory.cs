using System; 
using OnlineOrderApp.Enums; 

namespace OnlineOrderApp.Models {
    /// <summary>
    /// Represents a record of a status change for an order.
    /// </summary>
    public class OrderHistory // Declares the OrderHistory class
    { 

        #region Properties // This region contains all properties of the OrderHistory class

        /// <summary>
        /// Gets the previous status of the order before the change.
        /// </summary>
        public OrderStatus FromStatus { get; } // Property to store the old status

        /// <summary>
        /// Gets the new status of the order after the change.
        /// </summary>
        public OrderStatus ToStatus { get; } // Property to store the new status

        /// <summary>
        /// Gets the date and time when the status change occurred.
        /// </summary>
        public DateTime ChangedOn { get; } // Property to store the timestamp of the change

        #endregion

        #region Constructors // This region contains all constructors for the OrderHistory class

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderHistory"/> class with the specified statuses.
        /// </summary>
        /// <param name="from">The previous status.</param>
        /// <param name="to">The new status.</param>
        public OrderHistory(OrderStatus from, OrderStatus to) // Constructor that sets the previous and new status
        { 
            FromStatus = from; // Assigns the previous status to the FromStatus property
            ToStatus = to; // Assigns the new status to the ToStatus property
            ChangedOn = DateTime.Now; // Sets the change time to the current date and time
        } 

        #endregion
    } 
} 
