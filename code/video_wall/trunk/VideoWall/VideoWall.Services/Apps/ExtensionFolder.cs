using System.ComponentModel.Composition;
using System.IO;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Apps
{
    internal class ExtensionFolder
    {
        public DirectoryInfo Directory { get; private set; }

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        [Import]
        public IApp App { get; private set; }

        public ExtensionFolder(DirectoryInfo directory)
        {
            Directory = directory;
        }

        public bool Loaded()
        {
            return App != null;
        }
    }
}