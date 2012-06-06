using System.Collections.Generic;

namespace LunchMenuApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The lunch menu parser interface
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
        /// <returns> </returns>
        string ExtractDate();

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> </returns>
        List<IDish> ExtractDishes();

    }
}