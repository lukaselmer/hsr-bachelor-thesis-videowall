using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="menuViewModel">The menu view model.</param>
        /// <param name="playerViewModel">The player view model.</param>
        /// <param name="cursorViewModel">The cursor view model.</param>
        public MainWindowViewModel(MenuViewModel menuViewModel, PlayerViewModel playerViewModel, ICursorViewModel cursorViewModel)
        {
            MenuViewModel = menuViewModel;
            PlayerViewModel = playerViewModel;
            CursorViewModel = cursorViewModel;
        }

        public MenuViewModel MenuViewModel { get; set; }
        public PlayerViewModel PlayerViewModel { get; set; }
        public ICursorViewModel CursorViewModel { get; set; }
    }
}
