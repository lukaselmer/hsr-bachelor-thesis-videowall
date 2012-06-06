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
    ///   The menu style view model defines the style for the menu.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
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

        /// <summary>
        ///   Gets the color of the bottom line of the tab.
        /// </summary>
        /// <value> The color of the bottom line. </value>
        public Color BottomLineColor { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MenuStyleViewModel" /> class.
        /// </summary>
        /// <param name="fontColor"> Color of the font. </param>
        /// <param name="colorTop"> The color top gradient brush. </param>
        /// <param name="colorBottom"> The color bottom gradient brush. </param>
        /// <param name="bottomLine"> The bottom line color of the tab. </param>
        public MenuStyleViewModel(Color fontColor, Color colorTop, Color colorBottom, Color bottomLine)
        {
            FontColor = fontColor;
            LightColor = colorTop;
            DarkColor = colorBottom;
            BottomLineColor = bottomLine;
        }

        #endregion
    }
}
