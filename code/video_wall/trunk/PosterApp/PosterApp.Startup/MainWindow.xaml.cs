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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoWall.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Views.Xaml;

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
            //var posterLoader = new ResourceLoader.ResourceLoader();
            //var unityContainer = new UnityContainer().LoadConfiguration();
            //PosterContainer.Children.Add(unityContainer.Resolve<PosterView>());
        }
    }

    public class LocalAppInfo : IVideoWallServiceProvider
    {
        private UnityContainer _container;

        public LocalAppInfo(string filepath)
        {
            _container = new UnityContainer();
            _container.RegisterInstance<IFileService>(new LocalFileService(filepath));
        }

        public T GetExtension<T>() where T : IVideoWallService
        {
            return _container.Resolve<T>();
        }
    }

    public class LocalFileService : IFileService
    {
        public LocalFileService(string directory)
        {
            ResourceDirectory = directory;
        }

        public string ResourceDirectory { get; private set; }
    }
}
