using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Views.Xaml;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

            var container = new UnityContainer().LoadConfiguration();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleAndDisplayException(new Exception("Exception: " + e.ExceptionObject));
        }

        private static void HandleAndDisplayException(Exception ex)
        {
            Common.Logger.Get.Error(ex.Message, ex);
            MessageBox.Show(String.Format("Hi! We are sorry, but the an exception occured. The application will now terminate, see log for details." +
                "Your Video Wall team.\n\n" +
                "{0}\nMessage: {1}", ex.GetType(), ex.Message));
            Current.Shutdown(1);
        }
    }
}
