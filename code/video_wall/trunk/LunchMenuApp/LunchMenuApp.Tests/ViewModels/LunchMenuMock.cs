using System.Collections.Generic;
using LunchMenuApp.ServiceModels.Interfaces;

namespace LunchMenuApp.Tests.ViewModels
{
    /// <summary>
    /// The lunch menu mock.
    /// </summary>
    public class LunchMenuMock : ILunchMenu
    {
        /// <summary>
        ///   Gets the dishes.
        /// </summary>
        public IEnumerable<IDish> Dishes { get; set; }

        /// <summary>
        ///   Gets the date.
        /// </summary>
        public string Date { get; set; }
    }
}