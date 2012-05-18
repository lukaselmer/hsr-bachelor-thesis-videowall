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
using Interfaces;
using Microsoft.Practices.Unity;
using LunchMenuApp = LunchMenuApp.Main.LunchMenuApp;

namespace LunchMenuApp.Startup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            IApp app = new Main.LunchMenuApp();
            app.Activate(new LocalAppInfo());
            LunchMenuContainer.Children.Add(app.MainView);

            //var posterLoader = new ResourceLoader.ResourceLoader();
            //var unityContainer = new UnityContainer().LoadConfiguration();
            //PosterContainer.Children.Add(unityContainer.Resolve<PosterView>());
        }
    }

    public class LocalAppInfo : IVideoWallServiceProvider
    {
        public T GetExtension<T>() where T : IVideoWallService
        {
            return default(T);
        }
    }
}
