using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
//        protected override void OnStartup(StartupEventArgs e)
//        {
//            base.OnStartup(e);
//            var container = new UnityContainer().LoadConfiguration();
//            //container.Resolve<MainWindow>().Show();
//            container.Resolve<PlayerWindow>().Show();
//        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var container = new UnityContainer().LoadConfiguration();
            container.Resolve<MainWindow>().Show();
            container.Resolve<PlayerWindow>().Show();

        }
    }
}
