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
using System.Linq;
using System.Windows.Input;
using VideoWall.Common;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Apps;
using VideoWall.ViewModels.Helpers;

#endregion

namespace VideoWall.ViewModels.Menu
{
    /// <summary>
    ///   The MenuViewModel. Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    public class MenuViewModel : Notifier
        // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly AppController _appController;
        private readonly Random _random;
        private IApp _currentApp;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the apps.
        /// </summary>
        public ObservableCollection<IApp> Apps { get; private set; }

        /// <summary>
        ///   This command changes the current application.
        /// </summary>
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        // ReSharper disable MemberCanBePrivate.Global
        public ICommand ChangeAppCommand { get; private set; }

        // ReSharper restore MemberCanBePrivate.Global
        // ReSharper restore UnusedAutoPropertyAccessor.Global

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

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MenuViewModel" /> class.
        /// </summary>
        /// <param name="appController"> The app controller </param>
        public MenuViewModel(AppController appController)
        {
            _appController = appController;
            Apps = _appController.Apps;
            CurrentApp = Apps.First();
            ChangeAppCommand = new Command(OnChangeApp);
            _random = new Random();
        }

        #endregion

        #region Methods

        private void OnChangeApp(object appObject)
        {
            var app = appObject as IApp;
            PreOrPostCondition.AssertNotNull(app, "appObject is null or not of type IApp");
            CurrentApp = app;
        }

        /// <summary>
        ///   Changes the app.
        /// </summary>
        public void ChangeApp()
        {
            CurrentApp = Apps[_random.Next(0, Apps.Count)];
        }

        #endregion
    }
}
