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
using System.IO;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   The file service provides a directory where an exension has read and write access.
    /// </summary>
    public class FileService : IFileService
    {
        #region Properties

        /// <summary>
        ///   Gets the path to the resource directory.
        /// </summary>
        public string ResourceDirectory { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="extensionsConfig">The extensions config.</param>
        public FileService(IApp app, ExtensionsConfig extensionsConfig)
        {
            var resourceDirectoryInfo = new DirectoryInfo(String.Format("{0}/Files/{1}", extensionsConfig.ExtensionsDirectoryPath.FullName, app.Name));
            if(!resourceDirectoryInfo.Exists) resourceDirectoryInfo.Create();
            ResourceDirectory = resourceDirectoryInfo.FullName;
        }

        #endregion
    }
}