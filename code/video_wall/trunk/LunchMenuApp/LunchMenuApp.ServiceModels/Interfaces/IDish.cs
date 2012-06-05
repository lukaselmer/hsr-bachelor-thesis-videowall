namespace LunchMenuApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The dish interface.
    /// </summary>
    public interface IDish
    {
        /// <summary>
        ///   Gets the type.
        /// </summary>
        string Type { get; }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///   Gets the price.
        /// </summary>
        string Price { get; }
    }
}