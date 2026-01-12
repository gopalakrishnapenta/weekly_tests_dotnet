


namespace OnlineOrderApp.Models {
    /// <summary>
    /// Represents a product that can be ordered by a customer.
    /// </summary>
    public class Product // Declares the Product class
    { 

        #region Properties // This region contains all properties of the Product class

        /// <summary>
        /// Gets the unique identifier for the product.
        /// </summary>
        public int Id { get; } // Property to store the product's unique ID

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; } // Property to store the product's name

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public decimal Price { get; } // Property to store the product's price

        #endregion

        #region Constructors // This region contains all constructors for the Product class

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified ID, name, and price.
        /// </summary>
        /// <param name="id">The unique identifier for the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        public Product(int id, string name, decimal price) // Constructor that sets the product's ID, name, and price
        { 
            Id = id; // Assigns the provided id to the Id property
            Name = name; // Assigns the provided name to the Name property
            Price = price; // Assigns the provided price to the Price property
        }

        #endregion
    } 
} 
