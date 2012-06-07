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

using System.IO;
using VideoWall.Interfaces;

#endregion

namespace PosterApp.Tests.Mocks
{
    /// <summary>
    /// A mock implementing the file service interface.
    /// </summary>
    public class FileServiceMock : IFileService
    {
        #region IFileService Members

        /// <summary>
        ///   Gets the path to the resource directory.
        /// </summary>
        public string ResourceDirectory { get { return "TestFiles"; } }

        /// <summary>
        /// Gets the test file path.
        /// </summary>
        public string TestFilePath { get { return Path.Combine(ResourceDirectory, "1.jpg"); } }

        #endregion
    }
}
