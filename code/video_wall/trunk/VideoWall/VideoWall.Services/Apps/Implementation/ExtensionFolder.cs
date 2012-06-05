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
using System.IO;
using VideoWall.Common.Helpers;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   The extension folder represents a folder in which exactly one video wall extension should exist.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class ExtensionFolder
    {
        #region Properties

        /// <summary>
        ///   Gets the directory where the extension should be found.
        /// </summary>
        public DirectoryInfo Directory { get; private set; }

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        [Import]
        public IApp App { get; private set; }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="ExtensionFolder" /> class.
        /// </summary>
        /// <param name="directory"> The directory. </param>
        public ExtensionFolder(DirectoryInfo directory)
        {
            PreOrPostCondition.AssertNotNull(directory, "directory");
            PreOrPostCondition.AssertTrue(directory.Exists, string.Format("Directory {0} does not exist", directory.FullName));

            Directory = directory;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Determines whether this instance is loaded.
        /// </summary>
        /// <returns> <c>true</c> if this instance is loaded; otherwise, <c>false</c> . </returns>
        public bool IsLoaded()
        {
            return App != null;
        }

        #endregion
    }
}
