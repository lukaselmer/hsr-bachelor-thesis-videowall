using System.Windows.Input;

namespace ViewModels
{
    public class MainWindowViewModel
    {
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
