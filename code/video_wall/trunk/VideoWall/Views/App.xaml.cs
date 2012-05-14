#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Windows;
using System.Windows.Threading;
using Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Views.Xaml;

#endregion

namespace Views
{
    /// <summary>
    ///   Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        ///   Entry point. Start the application.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.Windows.StartupEventArgs" /> instance containing the event data. </param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += OnApplicationUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;

            var container = new UnityContainer().LoadConfiguration();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

            throw new Exception("aisdufhiwuehfiuh");
        }

        /// <summary>
        /// Called when a unhandled exception occurs in the GUI thread.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Threading.DispatcherUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void OnApplicationUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            OnUnhandledException(e.Exception);
        }

        /// <summary>
        ///   Called when a unhandled exception occurs in any thread.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.UnhandledExceptionEventArgs" /> instance containing the event data. </param>
        private static void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            OnUnhandledException(e.ExceptionObject as Exception ?? new Exception("Exception: " + e.ExceptionObject));
            HandleException();
        }

        /// <summary>
        /// Called when a unhandled exception occured.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private static void OnUnhandledException(Exception exception)
        {
            LogAndDisplayException(exception);
            HandleException();
        }

        /// <summary>
        ///   Handles the exception. The most simple case is just to shutdown the application, but more elegant would be to restart the application or even popup a "rescue application" which reports the error and on which the user can choose the next action (e.g. restart application, restart server, debug mode, ...)
        /// </summary>
        private static void HandleException()
        {
            Current.Shutdown(1);
        }

        /// <summary>
        ///   Logs the and displays the exception.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        private static void LogAndDisplayException(Exception ex)
        {
            Logger.Get.Error(ex.Message, ex);
            var message = String.Format("Hi! We are sorry, but the an exception occured. The application will now terminate, see log for details." +
                "Your Video Wall team.\n\n" +
                    "{0}\nMessage: {1}", ex.GetType(), ex.Message);
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}