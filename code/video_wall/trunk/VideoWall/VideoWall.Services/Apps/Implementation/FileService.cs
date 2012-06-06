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
using VideoWall.Common.Exceptions;
using VideoWall.Common.Logging;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   The file service provides a directory where an exension has read and write access.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class FileService : IFileService
    // ReSharper restore ClassNeverInstantiated.Global
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
        ///   Initializes a new instance of the <see cref="FileService" /> class.
        /// </summary>
        /// <param name="extensionFolder"> The extension folder. </param>
        public FileService(ExtensionFolder extensionFolder)
        {
            var directoryForFiles = new DirectoryInfo(Path.Combine(extensionFolder.Directory.FullName, SubdirectoryNameForFileService));
            if (!directoryForFiles.Exists)
            {
                var message = String.Format("The extension in the extension folder {0} has requested a file service, but the directory for this file service is missing. " +
                    "To confirm that the extension may use a file service, please create the following folder: {1}", extensionFolder.Directory, directoryForFiles.FullName);
                Logger.Get.Error(message);
                throw new VideoWallException(message);
            }
            ResourceDirectory = directoryForFiles.FullName;
        }

        #endregion
    }
}
