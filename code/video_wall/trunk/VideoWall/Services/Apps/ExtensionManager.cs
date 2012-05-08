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

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

#endregion

namespace Services.Apps
{
    /// <summary>
    ///   The extension manager is responsible for loading the extensions
    /// </summary>
    public static class ExtensionManager
    {
        /// <summary>
        ///   The folder name for the extensions
        /// </summary>
        private const string FolderNameOfExtensions = "../../../Extensions";

        /// <summary>
        ///   Inits the specified app with extension.
        /// </summary>
        /// <param name="appWithExtension"> The app with extension. </param>
        public static void Init(object appWithExtension)
        {
            CreateExtensionsDirectory();

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
        private static void CreateExtensionsDirectory()
        {
            if (!Directory.Exists(FolderNameOfExtensions)) Directory.CreateDirectory(FolderNameOfExtensions);
        }

        /*private static void RefreshCatalogs(AggregateCatalog catalog)
        {
            foreach (var directoryCatalog in catalog.Catalogs.OfType<DirectoryCatalog>())
            {
                directoryCatalog.Refresh();
            }
        }*/
    }
}