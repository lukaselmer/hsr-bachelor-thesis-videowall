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

        // TODO: extract these colors to config

        private static readonly MenuStyleViewModel SelectedMenuStyle = new MenuStyleViewModel(
            Colors.Black, Color.FromRgb(0xee, 0xee, 0xee), Colors.White, Colors.White);
        private static readonly MenuStyleViewModel UnselectedMenuStyle = new MenuStyleViewModel(
            Colors.White, Color.FromRgb(0x33, 0x84, 0xb5), Color.FromRgb(0x66, 0xa3, 0xc8), Color.FromRgb(0x33, 0x33, 0x33));

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
            private get { return _selected; }
            set
            {
                _selected = value;
                Notify("Selected");
                Notify("MenuStyle");
            }
        }

        /// <summary>
        ///   Gets or sets the menu style.
        /// </summary>
        /// <value> The menu style. </value>
        public MenuStyleViewModel MenuStyle { get { return Selected ? SelectedMenuStyle : UnselectedMenuStyle; } }

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
}
