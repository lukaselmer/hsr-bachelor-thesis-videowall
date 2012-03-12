using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecorderViewModel _recorder;

        public MainWindow(RecorderViewModel recorder)
        {
            InitializeComponent();
            DataContext = _recorder = recorder;
        }
    }
}
