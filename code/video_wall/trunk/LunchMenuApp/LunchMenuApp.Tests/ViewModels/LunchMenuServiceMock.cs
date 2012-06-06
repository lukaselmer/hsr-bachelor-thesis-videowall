using System;
using LunchMenuApp.ServiceModels.Interfaces;

namespace LunchMenuApp.Tests.ViewModels
{
    /// <summary>
    /// The lunch menu service mock.
    /// </summary>
    public class LunchMenuServiceMock : ILunchMenuService
    {
        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        public ILunchMenu LunchMenu { get; set; }

        /// <summary>
        /// Occurs when the lunch menu has changed.
        /// </summary>
        public event EventHandler LunchMenuChanged;

        /// <summary>
        /// Called when lunch menu changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void OnLunchMenuChanged(object sender, EventArgs eventArgs)
        {
            LunchMenuChanged(sender, eventArgs);
        }
    }
}