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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Common;
using LunchMenuApp.ServiceModels;
using LunchMenuApp.ViewModels;
using ServiceModels;

#endregion

namespace ViewModels.Lunch
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuViewModel : Notifier
    {
        private readonly LunchMenuService _lunchMenuService;
        private string _title;
        private ObservableCollection<DishViewModel> _dishes = new ObservableCollection<DishViewModel>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuViewModel" /> class.
        /// </summary>
        /// <param name="lunchMenuService"> The lunch menu service. </param>
        public LunchMenuViewModel(LunchMenuService lunchMenuService)
        {
            _lunchMenuService = lunchMenuService;
            _lunchMenuService.PropertyChanged += LunchMenuServiceChanged;
            UpdateLunchMenu();
        }

        private void UpdateLunchMenu()
        {
            Title = _lunchMenuService.LunchMenu.Date;
            Notify("Title");

            Dishes.Clear();
            foreach (var dish in _lunchMenuService.LunchMenu.Dishes)
            {
                Dishes.Add(new DishViewModel(dish));
            }
        }

        /// <summary>
        ///   Calls LoadMenu when LunchMenuService was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void LunchMenuServiceChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateLunchMenu();
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
                Notify("Title");
            }
        }

        /// <summary>
        /// Gets the dishes.
        /// </summary>
        public ObservableCollection<DishViewModel> Dishes
        {
            get
            {
                return _dishes;
            }
            private set
            {
                _dishes = value;
                Notify("Dishes");
            }
        }

    }
}