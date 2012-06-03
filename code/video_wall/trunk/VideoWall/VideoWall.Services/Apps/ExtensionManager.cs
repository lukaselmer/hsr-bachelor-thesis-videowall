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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using VideoWall.Common;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   The extension manager is responsible for loading the extensions
    /// </summary>
    public static class ExtensionManager
    {
        #region Declarations

        #endregion

        #region Methods

        /// <summary>
        ///   Inits the specified application with extension.
        /// </summary>
        /// <param name="appWithExtension"> The application with extension. </param>
        /// <param name="extensionsConfig"> </param>
        public static void Init(object appWithExtension, ExtensionsConfig extensionsConfig)
        {
            PreOrPostCondition.AssertNotNull(appWithExtension, "appWithExtension");
            PreOrPostCondition.AssertNotNull(extensionsConfig, "extensionsConfig");

            var folderNameOfExtensions = extensionsConfig.ExtensionsDirectoryPath.FullName;

            var catalog = new AggregateCatalog(new DirectoryCatalog(folderNameOfExtensions), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(appWithExtension);

            // var watcher = new FileSystemWatcher(folderNameOfExtensions) { EnableRaisingEvents = true };
            //var disp = Dispatcher.CurrentDispatcher;
            //watcher.Changed += (o, args) => disp.Invoke(new Action(() => RefreshCatalogs(catalog)));
        }

        /*private static void RefreshCatalogs(AggregateCatalog catalog)
        {
            foreach (var directoryCatalog in catalog.Catalogs.OfType<DirectoryCatalog>())
            {
                directoryCatalog.Refresh();
            }
        }*/

        #endregion
    }
}