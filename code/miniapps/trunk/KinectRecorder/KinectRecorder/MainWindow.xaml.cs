using System.Windows;
using Services;
using ViewModels;

namespace KinectRecorderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecorderViewModel _recorder;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _recorder = new RecorderViewModel(new Recorder());
        }
    }
}
