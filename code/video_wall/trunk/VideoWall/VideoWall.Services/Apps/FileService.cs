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
using System.Reflection;
using VideoWall.Common;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   The file service provides a directory where an exension has read and write access.
    /// </summary>
    internal class FileService : IFileService
    {
        private const string SubdirectoryNameForFileService = "Files";

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
        /// <param name="extensionFolder">The extension folder.</param>
        public FileService(ExtensionFolder extensionFolder)
        {
            var directoryForFiles = new DirectoryInfo(Path.Combine(extensionFolder.Directory.FullName, SubdirectoryNameForFileService));
            if (!directoryForFiles.Exists)
            {
                var message = String.Format("The extension in the extension folder {0} has requested a file service, but the directory for this file service is missing. " +
                    "To confirm that the extension may use a file service, please create the following folder: {1}", extensionFolder.Directory, directoryForFiles.FullName);
                Logger.Get.Error(message);
                throw new Exception(message);
            }
            ResourceDirectory = directoryForFiles.FullName;
        }

        #endregion
    }
}