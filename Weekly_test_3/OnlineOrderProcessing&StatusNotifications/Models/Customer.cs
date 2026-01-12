namespace OnlineOrderApp.Models 
{
    /// <summary>
    /// Represents a customer who can place orders in the system.
    /// </summary>
    public class Customer // Declares the Customer class
    { 

        #region Properties // This region contains all properties of the Customer class

        /// <summary>
        /// Gets the unique identifier for the customer.
        /// </summary>
        public int Id { get; } // Property to store the customer's unique ID

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name { get; } // Property to store the customer's name

        #endregion

        #region Constructors // This region contains all constructors for the Customer class

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID and name.
        /// </summary>
        /// <param name="id">The unique identifier for the customer.</param>
        /// <param name="name">The name of the customer.</param>
        public Customer(int id, string name) // Constructor that sets the customer's ID and name
        { 
            Id = id; // Assigns the provided id to the Id property
            Name = name; // Assigns the provided name to the Name property
        } 

        #endregion
    } 
} 
