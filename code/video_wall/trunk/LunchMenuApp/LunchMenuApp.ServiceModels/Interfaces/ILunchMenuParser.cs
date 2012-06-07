using System.Collections.Generic;

namespace LunchMenuApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The lunch menu parser interface.
    /// </summary>
    public interface ILunchMenuParser
    {
        /// <summary>
        /// Sets the HTML to be parsed.
        /// </summary>
        /// <value>
        /// The HTML.
        /// </value>
        string Html { set; }

        /// <summary>
        ///   Extracts the date.
        /// </summary>
        /// <returns> The date. </returns>
        string ExtractDate();

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> The dishes. </returns>
        List<IDish> ExtractDishes();

    }
}