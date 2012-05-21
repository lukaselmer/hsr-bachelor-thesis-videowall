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

using VideoWall.Common;
using VideoWall.ViewModels.Cursor;
using VideoWall.ViewModels.DemoMode;
using VideoWall.ViewModels.Menu;
using VideoWall.ViewModels.Skeletton;

#endregion

namespace VideoWall.ViewModels.Main
{
    /// <summary>
    ///   The MainWindowViewModel. Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
// ReSharper disable ClassNeverInstantiated.Global
    public class MainWindowViewModel : Notifier
// ReSharper restore ClassNeverInstantiated.Global
    {
        #region Properties

        /// <summary>
        ///   Gets or sets the demo mode view model.
        /// </summary>
        /// <value> The demo mode view model. </value>
        public DemoModeViewModel DemoModeViewModel { get; set; }

        /// <summary>
        ///   Gets or sets the menu view model.
        /// </summary>
        /// <value> The menu view model. </value>
        public MenuViewModel MenuViewModel { get; set; }

        /// <summary>
        ///   Gets or sets the player view model.
        /// </summary>
        /// <value> The player view model. </value>
        public PlayerViewModel PlayerViewModel { get; set; }

        /// <summary>
        ///   Gets or sets the cursor view model.
        /// </summary>
        /// <value> The cursor view model. </value>
        public ICursorViewModel CursorViewModel { get; set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="menuViewModel"> The menu view model. </param>
        /// <param name="playerViewModel"> The player view model. </param>
        /// <param name="cursorViewModel"> The cursor view model. </param>
        /// <param name="demoModeViewModel"> The demo mode view model. </param>
        public MainWindowViewModel(MenuViewModel menuViewModel, PlayerViewModel playerViewModel, ICursorViewModel cursorViewModel, DemoModeViewModel demoModeViewModel)
        {
            MenuViewModel = menuViewModel;
            PlayerViewModel = playerViewModel;
            CursorViewModel = cursorViewModel;
            DemoModeViewModel = demoModeViewModel;
        }

        #endregion
    }
}