using System.Windows;
using System.Windows.Media;

namespace DemoMode
{
    public partial class DemoModeView
    {
        public DemoModeView()
        {
            InitializeComponent();
            DemoModeTimer = new DemoModeTimer();
            DataContext = DemoModeTimer;
        }

        protected DemoModeTimer DemoModeTimer { get; private set; }

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DemoModeTimer.SkeletonChanged();
        }
    }
}