using System.Windows;
using BrowserApp.App;

namespace BrowserApp.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var app = new BrowserAppImpl();
            window.Content = app.MainView;
        }
    }
}
