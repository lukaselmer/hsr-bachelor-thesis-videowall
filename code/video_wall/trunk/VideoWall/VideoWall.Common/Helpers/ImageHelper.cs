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

#endregion

namespace VideoWall.Common.Helpers
{
    /// <summary>
    ///   The image helper provides helper methods for images.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public static class ImageHelper
    {
        #region Methods

        /// <summary>
        ///   Initializes an image with a file name.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> The image. </returns>
        // ReSharper disable UnusedMember.Global
        // Not used in all solutions.
        public static BitmapImage InitWithFileName(string fileName)
        // ReSharper restore UnusedMember.Global
        {
            var image = new BitmapImage();
            image.BeginInit();
            using (image.StreamSource = File.OpenRead(fileName))
            {
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze();
            }
            return image;
        }

        #endregion
    }
}
