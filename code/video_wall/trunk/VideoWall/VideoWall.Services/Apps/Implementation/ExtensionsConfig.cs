#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using System.IO;
using VideoWall.Common.Exceptions;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   The extensions configuration
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class ExtensionsConfig
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Properties

        /// <summary>
        ///   Gets or sets the extensions directory path.
        /// </summary>
        /// <value> The extensions directory path. </value>
        private DirectoryInfo ExtensionsDirectory { get; set; }

        /// <summary>
        ///   Gets the extension directories.
        /// </summary>
        public IEnumerable<DirectoryInfo> ExtensionDirectories { get { return ExtensionsDirectory.GetDirectories(); } }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="ExtensionsConfig" /> class.
        /// </summary>
        /// <param name="extensionsDirectoryPath"> The extensions directory path. </param>
        public ExtensionsConfig(string extensionsDirectoryPath)
        {
            ExtensionsDirectory = new DirectoryInfo(extensionsDirectoryPath);
            if (!ExtensionsDirectory.Exists) throw new VideoWallException("ExtensionsDirectory does not exist.");
        }

        #endregion
    }
}
