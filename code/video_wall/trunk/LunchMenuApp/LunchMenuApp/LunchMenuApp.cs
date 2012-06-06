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
using LunchMenuApp.Data.Implementation;
using LunchMenuApp.Data.Interfaces;
using LunchMenuApp.ServiceModels.Implementation;
using LunchMenuApp.ServiceModels.Interfaces;
using LunchMenuApp.Views;
using Microsoft.Practices.Unity;
using VideoWall.Interfaces;

#endregion

namespace LunchMenuApp.Main
{
    /// <summary>
    ///   Initializes a new lunch menu app.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    [Export(typeof(IApp))]
    public class LunchMenuApp : IApp
    {
        #region Properties

        /// <summary>
        ///   Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///   Gets the demomode text.
        /// </summary>
        public string DemomodeText { get; private set; }

        /// <summary>
        ///   Gets the main view.
        /// </summary>
        public UserControl MainView { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Constructs a new lunch menu app.
        /// </summary>
        public LunchMenuApp()
        {
            Name = "Mittagsmenü";
            DemomodeText = "Hunger?";
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Loads the app. At this place, the app can load or store application specific files for the application.
        /// </summary>
        /// <param name="videoWallServiceProvider"> The app info. </param>
        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
            var container = ConfigureUnityContainer();
            MainView = container.Resolve<LunchMenuView>();
        }

        /// <summary>
        /// Loads the and configures the unity container.
        /// </summary>
        /// <returns></returns>
        private static UnityContainer ConfigureUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUrlDownloader, WebDownloader>();
            container.RegisterType<ILunchMenuReader, LunchMenuReader>();
            container.RegisterType<ILunchMenuParser, LunchMenuParser>();
            container.RegisterType<ILunchMenuService, LunchMenuService>();
            container.RegisterType<ILunchMenu, LunchMenu>();
            return container;
        }

        #endregion
    }
}
