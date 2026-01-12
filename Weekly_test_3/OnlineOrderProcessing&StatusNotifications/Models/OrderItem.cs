
namespace OnlineOrderApp.Models 
{
    /// <summary>
    /// Represents a product and its quantity in an order.
    /// </summary>
    public class OrderItem // Declares the OrderItem class
    { 

        #region Properties // This region contains all properties of the OrderItem class

        /// <summary>
        /// Gets the product associated with this order item.
        /// </summary>
        public Product Product { get; } // Property to store the product

        /// <summary>
        /// Gets the quantity of the product in the order.
        /// </summary>
        public int Quantity { get; } // Property to store the quantity

        #endregion

        #region Constructors // This region contains all constructors for the OrderItem class

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem"/> class with the specified product and quantity.
        /// </summary>
        /// <param name="product">The product in the order.</param>
        /// <param name="quantity">The quantity of the product.</param>
        public OrderItem(Product product, int quantity) // Constructor that sets the product and quantity
        { 
            Product = product; // Assigns the provided product to the Product property
            Quantity = quantity; // Assigns the provided quantity to the Quantity property
        } 

        #endregion

        #region Public Methods // This region contains all public methods of the OrderItem class

        /// <summary>
        /// Calculates the total price for this order item.
        /// </summary>
        /// <returns>The total price (product price times quantity).</returns>
        public decimal TotalPrice() // Calculates the total price for this item
        { 
            return Product.Price * Quantity; // Multiplies product price by quantity and returns the result
        } 

        #endregion
    } 
} 
