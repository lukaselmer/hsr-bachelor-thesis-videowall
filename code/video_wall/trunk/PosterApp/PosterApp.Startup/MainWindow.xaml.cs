using VideoWall.Interfaces;

namespace PosterApp.Startup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            IApp app = new Main.PosterApp();
            app.Activate(new LocalAppInfo("./Poster"));
            PosterContainer.Children.Add(app.MainView);
        }
    }
}
