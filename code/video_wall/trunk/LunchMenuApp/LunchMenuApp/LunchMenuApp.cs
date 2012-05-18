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

using System.ComponentModel.Composition;
using System.Windows.Controls;
using Interfaces;
using LunchMenuApp.Views;
using Microsoft.Practices.Unity;

#endregion

namespace LunchMenuApp.Main
{
    /// <summary>
    /// Initializes a new launch menu app
    /// </summary>
    [Export(typeof(IApp))]
    public class LunchMenuApp : IApp
    {
        /// <summary>
        /// Constructs a new lunch menu app.
        /// </summary>
        public LunchMenuApp()
        {
            Name = "Mittagsmenü";
            DemomodeText = "Hunger?";
        }

        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the demomode text.
        /// </summary>
        public string DemomodeText { get; private set; }

        /// <summary>
        /// Gets the main view.
        /// </summary>
        public UserControl MainView { get; private set; }

        #endregion

        /// <summary>
        /// Loads the app. At this place, the app can load or store application specific files for the application.
        /// </summary>
        /// <param name="videoWallServiceProvider">The app info.</param>
        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
            var container = new UnityContainer();
            MainView = container.Resolve<LunchMenuView>();
        }
    }
}
