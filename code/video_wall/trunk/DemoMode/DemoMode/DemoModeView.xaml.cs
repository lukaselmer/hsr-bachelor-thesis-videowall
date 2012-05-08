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
        }

        protected DemoModeViewModel DemoModeViewModel { get; private set; }

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DemoModeViewModel.SkeletonWasChanged();
        }
    }
}