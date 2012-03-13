using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for RecorderWindow.xaml
    /// </summary>
    public partial class RecorderWindow : Window
    {
        private RecorderViewModel _recorder;

        public RecorderWindow(RecorderViewModel recorder)
        {
            InitializeComponent();
            DataContext = _recorder = recorder;
        }
    }
}
