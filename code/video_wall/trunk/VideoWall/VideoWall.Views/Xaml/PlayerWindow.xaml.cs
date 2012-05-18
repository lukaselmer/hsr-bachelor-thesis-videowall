using ViewModels.Skeletton;

namespace Views.Xaml
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow
    {
        private PlayerViewModel _player;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerWindow"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerWindow(PlayerViewModel player)
        {
            InitializeComponent();
            DataContext = _player = player;
        }
    }
}