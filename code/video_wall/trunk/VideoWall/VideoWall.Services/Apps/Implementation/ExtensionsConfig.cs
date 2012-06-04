using System.Collections.Generic;
using System.IO;
using VideoWall.Common;

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    /// The extensions configuration
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class ExtensionsConfig
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Properties

        /// <summary>
        /// Gets or sets the extensions directory path.
        /// </summary>
        /// <value>
        /// The extensions directory path.
        /// </value>
        private DirectoryInfo ExtensionsDirectoryPath { get; set; }

        /// <summary>
        /// Gets the extension directories.
        /// </summary>
        public IEnumerable<DirectoryInfo> ExtensionDirectories { get { return ExtensionsDirectoryPath.GetDirectories(); } }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionsConfig"/> class.
        /// </summary>
        /// <param name="extensionsDirectoryPath">The extensions directory path.</param>
        public ExtensionsConfig(string extensionsDirectoryPath)
        {
            ExtensionsDirectoryPath = new DirectoryInfo(extensionsDirectoryPath);
            PreOrPostCondition.AssertTrue(ExtensionsDirectoryPath.Exists, "ExtensionsDirectoryPath does not exist.");
        }

        #endregion
    }
}