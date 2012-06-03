using System.IO;
using VideoWall.Common;

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    /// The extensions configuration
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    public class ExtensionsConfig
    // ReSharper restore ClassNeverInstantiated.Global
    {
        /// <summary>
        /// Gets or sets the extensions directory path.
        /// </summary>
        /// <value>
        /// The extensions directory path.
        /// </value>
        public DirectoryInfo ExtensionsDirectoryPath { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionsConfig"/> class.
        /// </summary>
        /// <param name="extensionsDirectoryPath">The extensions directory path.</param>
        public ExtensionsConfig(string extensionsDirectoryPath)
        {
            ExtensionsDirectoryPath = new DirectoryInfo(extensionsDirectoryPath);
            PreOrPostCondition.AssertTrue(ExtensionsDirectoryPath.Exists, "ExtensionsDirectoryPath does not exist.");
        }
    }
}