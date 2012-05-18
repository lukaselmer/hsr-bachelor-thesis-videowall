#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using Common;
using LunchMenuApp.ServiceModels;

#endregion

namespace ServiceModels
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenu
    {
        /// <summary>
        /// Gets the dishes.
        /// </summary>
        public List<Dish> Dishes { get; private set; }

        /// <summary>
        /// Gets the date.
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenu"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        public LunchMenu(string html)
        {
            var parser = new LunchMenuParser(html);

            Date = parser.ExtractDate();
            Dishes = parser.ExtractMenus();
        }
    }
}