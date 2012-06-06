using System;

namespace LunchMenuApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The lunch menu service interface.
    /// </summary>
    public interface ILunchMenuService
    {
        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        ILunchMenu LunchMenu { get; }

        /// <summary>
        /// Occurs when the lunch menu has changed.
        /// </summary>
        event EventHandler LunchMenuChanged;
    }
}