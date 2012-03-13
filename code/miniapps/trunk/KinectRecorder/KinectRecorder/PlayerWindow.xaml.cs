using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Services.Player;
using Services.Recorder;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private PlayerViewModel _player;

        public PlayerWindow(PlayerViewModel player)
        {
            InitializeComponent();
            DataContext = _player = player;
        }
    }
}
