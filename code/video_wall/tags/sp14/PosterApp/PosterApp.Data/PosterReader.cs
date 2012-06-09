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

using System.Collections.Generic;
using System.IO;
using VideoWall.Interfaces;

#endregion

namespace PosterApp.Data
{
    /// <summary>
    ///   The Poster Reader
    /// </summary>
    public class PosterReader
    {
        #region Properties

        /// <summary>
        ///   Gets the path of the files.
        /// </summary>
        private string Path { get; set; }

        /// <summary>
        ///   Gets the files.
        /// </summary>
        public IEnumerable<string> Files { get { return Directory.GetFiles(Path, "*.jpg"); } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterReader" /> class.
        /// </summary>
        public PosterReader(IVideoWallServiceProvider serviceProvider)
        {
            var fileService = serviceProvider.GetExtension<IFileService>();
            Path = fileService.ResourceDirectory;
        }

        #endregion
    }
}
