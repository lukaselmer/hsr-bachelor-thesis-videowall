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

        /// <summary>
        ///   The folder name for the extensions
        /// </summary>
        private const string FolderNameOfExtensions = "../../../Extensions";

        #endregion

        #region Methods

        /// <summary>
        ///   Inits the specified application with extension.
        /// </summary>
        /// <param name="appWithExtension"> The application with extension. </param>
        public static void Init(object appWithExtension)
        {
            CreateDirectoryWith(FolderNameOfExtensions);

            var catalog = new AggregateCatalog(new DirectoryCatalog(FolderNameOfExtensions), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(appWithExtension);

            // var watcher = new FileSystemWatcher(FolderNameOfExtensions) { EnableRaisingEvents = true };
            //var disp = Dispatcher.CurrentDispatcher;
            //watcher.Changed += (o, args) => disp.Invoke(new Action(() => RefreshCatalogs(catalog)));
        }

        /// <summary>
        ///   Creates the extensions directory if it does not exist.
        /// </summary>
        private static void CreateDirectoryWith(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        /*private static void RefreshCatalogs(AggregateCatalog catalog)
        {
            foreach (var directoryCatalog in catalog.Catalogs.OfType<DirectoryCatalog>())
            {
                directoryCatalog.Refresh();
            }
        }*/

        /// <summary>
        /// Inits the app.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <returns></returns>
        public static string InitApp(IApp app)
        {
            var directoryName = String.Format("{0}/Files/{1}", FolderNameOfExtensions, app.Name);
            CreateDirectoryWith(directoryName);
            return directoryName;
        }

        #endregion
    }
}