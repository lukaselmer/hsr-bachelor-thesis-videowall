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

using System.Windows.Media;

#endregion

namespace VideoWall.ViewModels.Menu
{
    /// <summary>
    ///   The menu style view model defines the style for the menu
    /// </summary>
    public class MenuStyleViewModel
    {
        #region Properties

        /// <summary>
        ///   Gets the color of the font.
        /// </summary>
        /// <value> The color of the font. </value>
        public Color FontColor { get; private set; }

        /// <summary>
        ///   Gets the light color for the menu button
        /// </summary>
        /// <value> The color of the light. </value>
        public Color LightColor { get; private set; }

        /// <summary>
        ///   Gets the dark color for the menu button
        /// </summary>
        /// <value> The color of the dark. </value>
        public Color DarkColor { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MenuStyleViewModel" /> class.
        /// </summary>
        /// <param name="fontColor"> Color of the font. </param>
        /// <param name="colorTop"> Color of the light. </param>
        /// <param name="colorBottom"> Color of the dark. </param>
        public MenuStyleViewModel(Color fontColor, Color colorTop, Color colorBottom)
        {
            FontColor = fontColor;
            LightColor = colorTop;
            DarkColor = colorBottom;
        }

        #endregion
    }
}
