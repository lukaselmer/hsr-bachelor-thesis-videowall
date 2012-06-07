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

namespace LunchMenuApp.Tests.Mocks
{
    internal class LunchMenuParserMock : ILunchMenuParser
    {
        /// <summary>
        ///   Sets the extract date for the test.
        /// </summary>
        /// <value> The extract date for the test. </value>
        public string ExtractDateForTest { private get; set; }

        /// <summary>
        ///   Sets the extract dishes for the test.
        /// </summary>
        /// <value> The extract dishes for the test. </value>
        public List<IDish> ExtractDishesForTest { private get; set; }

        public bool Throwing { private get; set; }

        #region ILunchMenuParser Members

        /// <summary>
        ///   Sets the HTML to be parsed.
        /// </summary>
        /// <value> The HTML. </value>
        public string Html { set; private get; }

        /// <summary>
        ///   Extracts the date.
        /// </summary>
        /// <returns> </returns>
        public string ExtractDate()
        {
            if (Throwing) throw new Exception("Simulate parsing exception");
            return ExtractDateForTest;
        }

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> </returns>
        public List<IDish> ExtractDishes()
        {
            if (Throwing) throw new Exception("Simulate parsing exception");
            return ExtractDishesForTest;
        }

        #endregion
    }
}
