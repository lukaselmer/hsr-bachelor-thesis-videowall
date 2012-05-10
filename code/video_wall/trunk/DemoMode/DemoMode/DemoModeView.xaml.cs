using System;
using System.Windows;
using System.Windows.Media;

namespace DemoMode
{
    public partial class DemoModeView
    {
        public DemoModeView()
        {
            InitializeComponent();
            DemoModeViewModel = new DemoModeViewModel();
            DataContext = DemoModeViewModel;
            DemoModeViewModel.ModeTimer.DemoModeTimer.Tick += OnDemoModeTimerTick;
            DemoModeViewModel.ModeTimer.InteractionModeTimer.Tick += OnInteractionModeTimerTick;
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            DemoModeViewModel.ChangeColor();
            Visibility = Visibility.Visible;
        }

        private void OnDemoModeTimerTick(object sender, EventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        protected DemoModeViewModel DemoModeViewModel { get; private set; }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            DemoModeViewModel.ModeTimer.SkeletonChanged();
        }
    }
}