#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Windows.Media;
using VideoWall.Common;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ViewModels.Menu
{
    /// <summary>
    ///   The app view model wrapps the app
    /// </summary>
    public class AppViewModel : Notifier
    {
        #region Declarations

        private static readonly MenuStyleViewModel SelectedMenuStyle = new MenuStyleViewModel(Colors.Black, Color.FromRgb(0xEE, 0xEE, 0xEE), Color.FromRgb(0xFF, 0xFF, 0xFF));
        private static readonly MenuStyleViewModel UnselectedMenuStyle = new MenuStyleViewModel(Colors.White, Color.FromRgb(0x00, 0x7D, 0xFF), Color.FromRgb(0x0F, 0x37, 0x60));

        private IApp _app;
        private bool _selected;

        #endregion

        #region Properties

        /// <summary>
        ///   The app
        /// </summary>
        public IApp App
        {
            get { return _app; }
            set
            {
                _app = value;
                Notify("App");
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="AppViewModel" /> is active.
        /// </summary>
        /// <value> <c>true</c> if active; otherwise, <c>false</c> . </value>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                Notify("Selected");
                Notify("MenuStyle");
            }
        }

        /// <summary>
        /// Gets or sets the menu style.
        /// </summary>
        /// <value>
        /// The menu style.
        /// </value>
        public MenuStyleViewModel MenuStyle
        {
            get { return Selected ? SelectedMenuStyle : UnselectedMenuStyle; }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="AppViewModel" /> class.
        /// </summary>
        /// <param name="app"> The app. </param>
        public AppViewModel(IApp app)
        {
            App = app;
        }

        #endregion
    }

    /// <summary>
    /// The menu style view model defines the style for the menu
    /// </summary>
    public class MenuStyleViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuStyleViewModel"/> class.
        /// </summary>
        /// <param name="fontColor">Color of the font.</param>
        /// <param name="colorTop">Color of the light.</param>
        /// <param name="colorBottom">Color of the dark.</param>
        public MenuStyleViewModel(Color fontColor, Color colorTop, Color colorBottom)
        {
            FontColor = fontColor;
            LightColor = colorTop;
            DarkColor = colorBottom;
        }

        /// <summary>
        /// Gets the color of the font.
        /// </summary>
        /// <value>
        /// The color of the font.
        /// </value>
        public Color FontColor { get; private set; }

        /// <summary>
        /// Gets the light color for the menu button
        /// </summary>
        /// <value>
        /// The color of the light.
        /// </value>
        public Color LightColor { get; private set; }

        /// <summary>
        /// Gets the dark color for the menu button
        /// </summary>
        /// <value>
        /// The color of the dark.
        /// </value>
        public Color DarkColor { get; private set; }
    }
}
