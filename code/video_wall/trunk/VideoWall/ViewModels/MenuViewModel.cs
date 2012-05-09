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

using System.Collections.ObjectModel;
using System.Windows.Input;
using Common;
using Interfaces;
using Services.Apps;

#endregion

namespace ViewModels
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class MenuViewModel : Notifier
    {
        private readonly AppController _appController;
        private IApp _currentApp;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MenuViewModel" /> class.
        /// </summary>
        /// <param name="appController"> The app controller </param>
        /// <param name="posterViewModel"> The poster view model. </param>
        /// <param name="lunchMenuViewModel"> The lunch menu view model. </param>
        public MenuViewModel(AppController appController, PosterViewModel posterViewModel, LunchMenuViewModel lunchMenuViewModel)
        {
            _appController = appController;
            Apps = _appController.Apps;
            CurrentApp = Apps[0];

            PosterViewModel = posterViewModel;
            LunchMenuViewModel = lunchMenuViewModel;
            ShowPosterViewCommand = new Command(OnShowPosterView);
            ShowLunchMenuViewCommand = new Command(OnShowLunchMenuView);
            OnShowPosterView(null);
        }

        /// <summary>
        /// Gets the apps.
        /// </summary>
        protected ObservableCollection<IApp> Apps { get; private set; }

        /// <summary>
        ///   Gets the current app.
        /// </summary>
        public IApp CurrentApp
        {
            get { return _currentApp; }
            private set
            {
                _currentApp = value;
                Notify("CurrentApp");
            }
        }

        /// <summary>
        ///   Gets or sets the poster view model.
        /// </summary>
        /// <value> The poster view model. </value>
        public PosterViewModel PosterViewModel { get; set; }

        /// <summary>
        ///   Gets or sets the lunch menu view model.
        /// </summary>
        /// <value> The lunch menu view model. </value>
        public LunchMenuViewModel LunchMenuViewModel { get; set; }

        /// <summary>
        ///   Gets or sets the show lunch menu view command.
        /// </summary>
        /// <value> The show lunch menu view command. </value>
        public ICommand ShowLunchMenuViewCommand { get; set; }

        /// <summary>
        ///   Gets or sets the show poster view command.
        /// </summary>
        /// <value> The show poster view command. </value>
        public ICommand ShowPosterViewCommand { get; set; }

        /// <summary>
        ///   Called when [show poster view].
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnShowPosterView(object obj)
        {
            LunchMenuViewModel.IsLunchMenuViewVisible = false;
            PosterViewModel.IsPosterViewVisible = true;
        }

        /// <summary>
        ///   Called when [show lunch menu view].
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnShowLunchMenuView(object obj)
        {
            PosterViewModel.IsPosterViewVisible = false;
            LunchMenuViewModel.IsLunchMenuViewVisible = true;
        }
    }
}