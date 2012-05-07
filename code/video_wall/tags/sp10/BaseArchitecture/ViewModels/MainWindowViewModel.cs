using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Common;
using Interfaces;
using Services.Apps;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class MainWindowViewModel : Notifier
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="appController">The app controller. </param>
        /// <param name="menuViewModel">The menu view model.</param>
        /// <param name="playerViewModel">The player view model.</param>
        /// <param name="cursorViewModel">The cursor view model.</param>
        public MainWindowViewModel(MenuViewModel menuViewModel, PlayerViewModel playerViewModel, ICursorViewModel cursorViewModel)
        {
            MenuViewModel = menuViewModel;
            PlayerViewModel = playerViewModel;
            CursorViewModel = cursorViewModel;
        }

        /// <summary>
        /// Gets or sets the menu view model.
        /// </summary>
        /// <value>
        /// The menu view model.
        /// </value>
        public MenuViewModel MenuViewModel { get; set; }

        /// <summary>
        /// Gets or sets the player view model.
        /// </summary>
        /// <value>
        /// The player view model.
        /// </value>
        public PlayerViewModel PlayerViewModel { get; set; }

        /// <summary>
        /// Gets or sets the cursor view model.
        /// </summary>
        /// <value>
        /// The cursor view model.
        /// </value>
        public ICursorViewModel CursorViewModel { get; set; }

    }
}
