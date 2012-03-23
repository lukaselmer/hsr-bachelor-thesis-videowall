using System.Windows;
using Data.Kinect;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Services;
using Services.Recorder;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer().LoadConfiguration();
            container.Resolve<PlayerWindow>().Show();

            //var x = container.Resolve<ISkeletonReader>();
            //var recorder = new RecorderViewModel(new Recorder());
            //new RecorderWindow(recorder).Show();
        }
    }
}
