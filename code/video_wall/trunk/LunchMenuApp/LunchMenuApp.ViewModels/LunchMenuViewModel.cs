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
using System.Collections.ObjectModel;
using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.ViewHelpers;

#endregion

namespace LunchMenuApp.ViewModels
{
    /// <summary>
    ///   The lunch menu view model represents the lunch menu.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class can be made abstract, which is wrong.
    public class LunchMenuViewModel : Notifier
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The dishes.
        /// </summary>
        private readonly ObservableCollection<DishViewModel> _dishes = new ObservableCollection<DishViewModel>();

        /// <summary>
        /// The lunch menu service provides the lunch menu with the dishes.
        /// </summary>
        private readonly ILunchMenuService _lunchMenuService;

        /// <summary>
        /// The title of the lunch menu (e.g. current date).
        /// </summary>
        private string _title;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the title.
        /// </summary>
        public string Title
        {
            get { return _title; }
            private set
            {
                _title = value;
                Notify("Title");
            }
        }

        /// <summary>
        ///   Gets the dishes.
        /// </summary>
        public ObservableCollection<DishViewModel> Dishes { get { return _dishes; } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuViewModel" /> class.
        /// </summary>
        /// <param name="lunchMenuService"> The lunch menu service. </param>
        public LunchMenuViewModel(ILunchMenuService lunchMenuService)
        {
            _lunchMenuService = lunchMenuService;
            _lunchMenuService.LunchMenuChanged += LunchMenuServiceChanged;
            UpdateLunchMenu();
        }

        #endregion

        #region Methods

        private void UpdateLunchMenu()
        {
            Dishes.Clear();

            if (_lunchMenuService.LunchMenu == null)
            {
                Title = "nicht verfügbar";
                return;
            }

            Title = _lunchMenuService.LunchMenu.Date;
            foreach (var dish in _lunchMenuService.LunchMenu.Dishes) Dishes.Add(new DishViewModel(dish));
        }

        /// <summary>
        /// Calls LoadMenu when LunchMenuService was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LunchMenuServiceChanged(object sender, EventArgs eventArgs)
        {
            UpdateLunchMenu();
        }

        #endregion
    }
}
