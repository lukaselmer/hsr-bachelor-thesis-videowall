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
using System.Windows.Media.Imaging;
using PosterApp.ServiceModels.Interfaces;
using VideoWall.Common.Helpers;

#endregion

namespace PosterApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The Poster.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class Poster : IPoster
    {
        #region Properties

        /// <summary>
        ///   Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///   Gets the image.
        /// </summary>
        public BitmapImage Image { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="Poster" /> class.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        public Poster(string fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            Image = ImageHelper.InitWithFileName(fileName);
        }

        #endregion
    }
}
