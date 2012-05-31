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

using System.Collections.ObjectModel;
using System.ComponentModel;
using LunchMenuApp.ServiceModels;
using VideoWall.Common;

#endregion

namespace LunchMenuApp.ViewModels
{
    /// <summary>
    ///   The lunch menu view model represents the lunch menu.
    /// </summary>
// ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong
    public class LunchMenuViewModel : Notifier
// ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly ObservableCollection<DishViewModel> _dishes = new ObservableCollection<DishViewModel>();
        private readonly LunchMenuService _lunchMenuService;
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
        public LunchMenuViewModel(LunchMenuService lunchMenuService)
        {
            _lunchMenuService = lunchMenuService;
            _lunchMenuService.PropertyChanged += LunchMenuServiceChanged;
            UpdateLunchMenu();
        }

        #endregion

        #region Methods

        private void UpdateLunchMenu()
        {
            if (_lunchMenuService.LunchMenu == null)
            {
                Title = "nicht verfügbar";
                Dishes.Clear();
                return;
            }

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

        #endregion
    }
}
