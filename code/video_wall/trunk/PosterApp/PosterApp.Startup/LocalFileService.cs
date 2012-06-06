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

using VideoWall.Interfaces;

#endregion

namespace PosterApp.Startup
{
    /// <summary>
    /// The local file service.
    /// Only used for local development without video wall framework.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class LocalFileService : IFileService
    {
        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalFileService"/> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public LocalFileService(string directory)
        {
            ResourceDirectory = directory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the path to the resource directory
        /// </summary>
        public string ResourceDirectory { get; private set; }

        #endregion
    }
}
