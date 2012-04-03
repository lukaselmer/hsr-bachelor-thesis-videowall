using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow
    {
        private PlayerViewModel _player;

        public PlayerWindow(PlayerViewModel player)
        {
            InitializeComponent();
            DataContext = _player = player;
        }
    }
}