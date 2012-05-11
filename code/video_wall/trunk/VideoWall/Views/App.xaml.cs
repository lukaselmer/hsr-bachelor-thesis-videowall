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
        /// <summary>
        /// Entry point. Start the application.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.StartupEventArgs"/> instance containing the event data.</param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            var container = new UnityContainer().LoadConfiguration();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        /// <summary>
        /// Handles an unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogAndDisplayException(new Exception("Exception: " + e.ExceptionObject));
            HandleException();
        }

        /// <summary>
        /// Handles the exception. The most simple case is just to shutdown the application, but more elegant would be to restart the
        /// application or even popup a "rescue application" which reports the error and on which the user can choose the next action
        /// (e.g. restart application, restart server, debug mode, ...)
        /// </summary>
        private static void HandleException()
        {
            Current.Shutdown(1);
        }

        /// <summary>
        /// Logs the and displays the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private static void LogAndDisplayException(Exception ex)
        {
            Common.Logger.Get.Error(ex.Message, ex);
            MessageBox.Show(String.Format("Hi! We are sorry, but the an exception occured. The application will now terminate, see log for details." +
                "Your Video Wall team.\n\n" +
                "{0}\nMessage: {1}", ex.GetType(), ex.Message));
        }
    }
}
