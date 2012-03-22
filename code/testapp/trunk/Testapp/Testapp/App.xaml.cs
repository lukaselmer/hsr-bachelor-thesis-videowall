using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Unity;
using Services;
using UserInterface;

namespace Testapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();
            ConfigueContainer(container);

            var window = container.Resolve<MainWindow>();

            window.Show();
            
        }

        private static void ConfigueContainer(UnityContainer container)
        {
            container.RegisterType<IPostersService, PostersService>();
        }
    }
}
