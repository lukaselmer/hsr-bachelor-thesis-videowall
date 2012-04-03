using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var container = new UnityContainer().LoadConfiguration();
            container.Resolve<MainWindow>().Show();
            //container.Resolve<PlayerWindow>().Show();
        }
    }
}
