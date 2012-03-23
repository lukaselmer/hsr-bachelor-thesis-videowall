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
using Microsoft.Practices.Unity;
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
        private readonly PlayerViewModel _playerViewModel;

        public PlayerWindow(PlayerViewModel playerViewModel)
        {
            InitializeComponent();
            DataContext = _playerViewModel = playerViewModel;
            playerViewModel.StartOrStopCommand.Execute(null);

            var container = new UnityContainer();
            container.RegisterInstance(_playerViewModel.Player);
            container.Resolve<CursorWindow>().Show();
        }
    }
}
