﻿#region Header

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

#endregion

namespace Common
{
    /// <summary>
    ///   The image helper provides helper methods for images.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        ///   Initializes an image with a file name.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> </returns>
        public static BitmapImage InitWithFileName(string fileName)
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
    }
}