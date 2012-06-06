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
using System.ComponentModel.Composition.Hosting;
using VideoWall.Common.Helpers;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   The extension manager is responsible to load a extension from a specific folder
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal static class ExtensionManager
    {
        #region Methods

        /// <summary>
        ///   Inits the specified application with extension.
        /// </summary>
        /// <param name="extensionFolder"> The application with extension. </param>
        public static void Init(ExtensionFolder extensionFolder)
        {
            PreOrPostCondition.AssertNotNull(extensionFolder, "extensionFolder");
            var container = new CompositionContainer(new DirectoryCatalog(extensionFolder.Directory.FullName));
            container.ComposeParts(extensionFolder);
        }

        //
        // Additional info for possible extension:
        // If dynamic loading (of extensions while the application is running) is needed, try something like this:
        //
        // var watcher = new FileSystemWatcher(folderNameOfExtensions) { EnableRaisingEvents = true };
        // var disp = Dispatcher.CurrentDispatcher;
        // watcher.Changed += (o, args) => disp.Invoke(new Action(() => RefreshCatalogs(catalog)));
        //
        // and create this method:
        //
        // private static void RefreshCatalogs(AggregateCatalog catalog)
        // {
        //    foreach (var directoryCatalog in catalog.Catalogs.OfType<DirectoryCatalog>())
        //    {
        //        directoryCatalog.Refresh();
        //    }
        // }
        //
        // This might also be useful:
        //
        // var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        // foreach (var directory in extensionsConfig.ExtensionsDirectoryPath.GetDirectories())
        // {
        //    catalog.Catalogs.Add(new DirectoryCatalog(directory.FullName));
        // }
        //

        #endregion
    }
}
