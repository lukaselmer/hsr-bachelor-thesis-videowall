#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.IO;
using System.Windows.Media.Imaging;
using VideoWall.Common;

#endregion

namespace ServiceModels
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class Poster
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Poster" /> class.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        public Poster(string fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            Image = ImageHelper.InitWithFileName(fileName);
        }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///   Gets the image.
        /// </summary>
        public BitmapImage Image { get; private set; }
    }
}