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

#endregion

namespace Services
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenu
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenu" /> class.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        public LunchMenu(string fileName)
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