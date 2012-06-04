using System.ComponentModel.Composition;
using System.IO;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Apps.Implementation
{
    internal class ExtensionFolder
    {
        #region Properties

        public DirectoryInfo Directory { get; private set; }

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        [Import]
        public IApp App { get; private set; }

        #endregion

        #region Constructor / Destructor

        public ExtensionFolder(DirectoryInfo directory)
        {
            Directory = directory;
        }

        #endregion

        #region Methods

        public bool Loaded()
        {
            return App != null;
        }

        #endregion

    }
}