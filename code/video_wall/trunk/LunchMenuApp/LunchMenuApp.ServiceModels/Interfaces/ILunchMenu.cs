using System.Collections.Generic;

namespace LunchMenuApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The lunch menu interface.
    /// </summary>
    public interface ILunchMenu
    {
        /// <summary>
        ///   Gets the dishes.
        /// </summary>
        IEnumerable<IDish> Dishes { get; }

        /// <summary>
        ///   Gets the date.
        /// </summary>
        string Date { get; }
    }
}