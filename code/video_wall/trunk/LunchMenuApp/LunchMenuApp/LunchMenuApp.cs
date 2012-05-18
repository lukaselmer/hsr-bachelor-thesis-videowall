using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Data;
using Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ServiceModels;
using ViewModels.Lunch;
using Views.Xaml;

namespace LunchMenuApp.Main
{
    /// <summary>
    /// Initializes a new launch menu app
    /// </summary>
    [Export(typeof(IApp))]
    public class LunchMenuApp : IApp
    {
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

        /// <summary>
        /// Constructs a new lunch menu app
        /// </summary>
        public LunchMenuApp()
        {
            Name = "Mittagsmenü";
            DemomodeText = "Hunger?";
        }

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
