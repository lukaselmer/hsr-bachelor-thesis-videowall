using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;

namespace MasterApp
{
    public class ExtensionManager
    {
        private const string FolderNameOfExtensions = "Extensions";

        public static void Init(object appWithExtension)
        {
            CreateExtensionsDirectory();

            var catalog = new AggregateCatalog(new DirectoryCatalog(FolderNameOfExtensions), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(appWithExtension);

            var watcher = new FileSystemWatcher(FolderNameOfExtensions) { EnableRaisingEvents = true };
            var disp = Dispatcher.CurrentDispatcher;
            watcher.Changed += (o, args) => disp.Invoke(new Action(() => RefreshCatalogs(catalog)));
        }

        private static void CreateExtensionsDirectory()
        {
            if (!Directory.Exists(FolderNameOfExtensions)) Directory.CreateDirectory(FolderNameOfExtensions);
        }

        private static void RefreshCatalogs(AggregateCatalog catalog)
        {
            foreach (var directoryCatalog in catalog.Catalogs.OfType<DirectoryCatalog>())
            {
                directoryCatalog.Refresh();
            }
        }
    }
}