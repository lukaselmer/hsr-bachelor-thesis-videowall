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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VideoWall.Common;
using VideoWall.Common.Extensions;
using VideoWall.Common.Helpers;
using VideoWall.Common.ViewHelpers;
using VideoWall.ServiceModels.Apps.Interfaces;

#endregion

namespace VideoWall.ViewModels.Menu
{
    /// <summary>
    ///   The MenuViewModel defines the menu. Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class can be made abstract, which is wrong.
    public class MenuViewModel : Notifier
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The app controller
        /// </summary>
        private readonly IAppController _appController;

        /// <summary>
        /// The current app
        /// </summary>
        private AppViewModel _currentApp;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the apps.
        /// </summary>
        public List<AppViewModel> Apps { get; private set; }

        /// <summary>
        ///   This command changes the current application.
        /// </summary>
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        // ReSharper disable MemberCanBePrivate.Global
        // WPF is too dynamic for resharper
        public ICommand ChangeAppCommand { get; private set; }
        // ReSharper restore MemberCanBePrivate.Global
        // ReSharper restore UnusedAutoPropertyAccessor.Global

        /// <summary>
        ///   Gets the current app.
        /// </summary>
        public AppViewModel CurrentApp
        {
            get { return _currentApp; }
            private set
            {
                PreOrPostCondition.AssertNotNull(value, "CurrentApp value");
                if (_currentApp != null) CurrentApp.Selected = false;
                _currentApp = value;
                _currentApp.Selected = true;
                Notify("CurrentApp");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MenuViewModel" /> class.
        /// </summary>
        /// <param name="appController"> The app controller </param>
        public MenuViewModel(IAppController appController)
        {
            _appController = appController;
            Apps = new List<AppViewModel>(_appController.Apps.Select(app => new AppViewModel(app)));
            CurrentApp = Apps.First();

            ChangeAppCommand = new Command(OnChangeApp);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when app changed.
        /// </summary>
        /// <param name="appObject">The app object.</param>
        private void OnChangeApp(object appObject)
        {
            var app = appObject as AppViewModel;
            PreOrPostCondition.AssertNotNull(app, "appObject is null or not of type IApp");
            CurrentApp = app;
        }

        /// <summary>
        ///   Changes the app.
        /// </summary>
        public void ChangeToRandomApp()
        {
            CurrentApp = Apps.RandomElement();
        }

        #endregion
    }
}
