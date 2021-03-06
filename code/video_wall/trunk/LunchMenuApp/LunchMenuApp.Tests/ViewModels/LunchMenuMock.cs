#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using LunchMenuApp.ServiceModels.Interfaces;

#endregion

namespace LunchMenuApp.Tests.ViewModels
{
    /// <summary>
    ///   The lunch menu mock.
    /// </summary>
    public class LunchMenuMock : ILunchMenu
    {
        #region ILunchMenu Members

        /// <summary>
        ///   Gets the dishes.
        /// </summary>
        public IEnumerable<IDish> Dishes { get; set; }

        /// <summary>
        ///   Gets the date.
        /// </summary>
        public string Date { get; set; }

        #endregion
    }
}
