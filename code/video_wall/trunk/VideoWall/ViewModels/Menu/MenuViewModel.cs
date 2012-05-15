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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Common;
using Interfaces;
using ServiceModels.Apps;
using ViewModels.Helpers;
using ViewModels.Lunch;

#endregion

namespace ViewModels.Menu
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class MenuViewModel : Notifier
    {
        private readonly AppController _appController;
        private IApp _currentApp;
        private Random _random;

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

        private void OnChangeApp(object appObject)
        {
            var app = appObject as IApp;
            PreOrPostCondition.AssertNotNull(app, "appObject is null or not of type IApp");
            CurrentApp = app;
        }

        public void ChangeApp()
        {
            CurrentApp = Apps[_random.Next(0, Apps.Count)];
        }

        /// <summary>
        ///   Gets the apps.
        /// </summary>
        public ObservableCollection<IApp> Apps { get; private set; }

        /// <summary>
        /// This command changes the current application.
        /// </summary>
        public ICommand ChangeAppCommand { get; private set; }

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
    }
}