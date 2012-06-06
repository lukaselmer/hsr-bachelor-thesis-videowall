#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using LunchMenuApp.ServiceModels.Interfaces;

#endregion

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The lunch menu.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Delia Treichler, 17.04.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class LunchMenu : ILunchMenu
    {
        #region Properties

        /// <summary>
        ///   Gets the dishes.
        /// </summary>
        public IEnumerable<IDish> Dishes { get; private set; }

        /// <summary>
        ///   Gets the date.
        /// </summary>
        public string Date { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenu" /> class.
        /// </summary>
        /// <param name="html"> The HTML. </param>
        /// <param name="lunchMenuParser"> </param>
        /// <exception cref="LunchMenuUnparsableException">If the lunch menu is not parsable.</exception>
        public LunchMenu(string html, ILunchMenuParser lunchMenuParser)
        {
            try
            {
                var parser = lunchMenuParser;
                Date = parser.ExtractDate();
                Dishes = parser.ExtractDishes();
            }
            catch (Exception exception)
            {
                throw new LunchMenuUnparsableException(String.Format("Lunch menu is unparsable, html was:\n\n{0}", html), exception);
            }
        }

        #endregion
    }
}
