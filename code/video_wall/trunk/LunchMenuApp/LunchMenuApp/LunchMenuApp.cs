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
using System.Reflection;
using System.Windows.Controls;
using LunchMenuApp.Data.Interfaces;
using LunchMenuApp.Views;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
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
            var container = LoadAndConfigureUnityContainer();
            MainView = container.Resolve<LunchMenuView>();
        }

        /// <summary>
        /// Loads the and configures the unity container.
        /// </summary>
        /// <returns></returns>
        private static UnityContainer LoadAndConfigureUnityContainer()
        {
            var containerElement = new ContainerElement();
            containerElement.Registrations.Add(new RegisterElement { TypeName = "ILunchMenuReader", MapToName = "LunchMenuReader" });
            containerElement.Registrations.Add(new RegisterElement { TypeName = "ILunchMenuService", MapToName = "LunchMenuService" });
            containerElement.Registrations.Add(new RegisterElement { TypeName = "ILunchMenu", MapToName = "LunchMenu" });

            var section = new UnityConfigurationSection();
            section.Containers.Add(containerElement);
            section.Assemblies.Add(new AssemblyElement { Name = "LunchMenuApp.Data" });
            section.Namespaces.Add(new NamespaceElement { Name = "LunchMenuApp.Data.Interfaces" });
            section.Namespaces.Add(new NamespaceElement { Name = "LunchMenuApp.Data.Implementation" });
            section.Assemblies.Add(new AssemblyElement { Name = "LunchMenuApp.ServiceModels" });
            section.Namespaces.Add(new NamespaceElement { Name = "LunchMenuApp.ServiceModels.Interfaces" });
            section.Namespaces.Add(new NamespaceElement { Name = "LunchMenuApp.ServiceModels.Implementation" });

            var container = new UnityContainer();
            container.LoadConfiguration(section);
            return container;
        }

        #endregion
    }
}
