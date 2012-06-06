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
using LunchMenuApp.ServiceModels.Interfaces;

#endregion

namespace LunchMenuApp.Tests.ViewModels
{
    /// <summary>
    ///   The lunch menu service mock.
    /// </summary>
    public class LunchMenuServiceMock : ILunchMenuService
    {
        #region ILunchMenuService Members

        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        public ILunchMenu LunchMenu { get; set; }

        /// <summary>
        ///   Occurs when the lunch menu has changed.
        /// </summary>
        public event EventHandler LunchMenuChanged;

        #endregion

        /// <summary>
        ///   Called when lunch menu changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="eventArgs"> The <see cref="System.EventArgs" /> instance containing the event data. </param>
        public void OnLunchMenuChanged(object sender, EventArgs eventArgs)
        {
            LunchMenuChanged(sender, eventArgs);
        }
    }
}
