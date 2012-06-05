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
using Microsoft.Practices.Unity;
using PosterApp.Data.Implementation;
using PosterApp.Data.Interfaces;
using PosterApp.ServiceModels.Implementation;
using PosterApp.ServiceModels.Interfaces;
using PosterApp.Views;
using VideoWall.Interfaces;

#endregion

namespace PosterApp.Main
{
    /// <summary>
    /// The poster app.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    [Export(typeof(IApp))]
    public class PosterApp : IApp
    {
        #region Properties

        /// <summary>
        /// Gets the main view.
        /// </summary>
        public UserControl MainView { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the demomode text.
        /// </summary>
        public string DemomodeText { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PosterApp"/> class.
        /// </summary>
        public PosterApp()
        {
            Name = "Posters";
            DemomodeText = "Neugierig?";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Activates the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public void Activate(IVideoWallServiceProvider serviceProvider)
        {
            var container = ConfigureUnityContainer();
            container.RegisterInstance(serviceProvider);
            MainView = container.Resolve<PosterView>();
        }

        /// <summary>
        /// Loads the and configures the unity container.
        /// </summary>
        /// <returns></returns>
        private static UnityContainer ConfigureUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IPosterReader, PosterReader>();
            container.RegisterType<IPoster, Poster>();
            container.RegisterType<IPosterService, PosterService>();
            return container;
        }

        #endregion
    }
}
