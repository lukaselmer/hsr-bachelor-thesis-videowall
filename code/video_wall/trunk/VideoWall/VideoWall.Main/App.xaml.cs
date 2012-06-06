#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using VideoWall.Common.Exceptions;
using VideoWall.Common.Logging;
using VideoWall.Views.Xaml;

#endregion

namespace VideoWall.Main
{
    /// <summary>
    ///   Interaction logic for App.xaml.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public partial class App
    {
        #region Constructors / Destructor

        /// <summary>
        ///   Entry point. Start the application.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.Windows.StartupEventArgs" /> instance containing the event data. </param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += OnApplicationUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;

            try
            {
                var container = new UnityContainer().LoadConfiguration();
                var mainWindow = container.Resolve<MainWindow>();
                mainWindow.Show();
            }
            catch (Exception exception)
            {
                OnUnhandledException(exception);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Called when a unhandled exception occurs in the GUI thread.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.Windows.Threading.DispatcherUnhandledExceptionEventArgs" /> instance containing the event data. </param>
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
        ///   Called when a unhandled exception occured.
        /// </summary>
        /// <param name="exception"> The exception. </param>
        private static void OnUnhandledException(Exception exception)
        {
            LogAndDisplayException(exception);
            HandleException();
        }

        /// <summary>
        ///   Handles the exception. The most simple case is just to shutdown the application, but more elegant would be to
        /// restart the application or even popup a "rescue application" which reports the error and on which the user can
        /// choose the next action (e.g. restart application, restart server, debug mode, ...)
        /// </summary>
        private static void HandleException()
        {
            // Shutdown the application.
            Current.Shutdown(1);
            // If the application cannot shut down properly, ensure that everything is stopped eventually (after 4000 milliseconds).
            new Timer(state => Process.GetCurrentProcess().Kill(), null, 4000, Timeout.Infinite);
        }

        /// <summary>
        ///   Logs the and displays the exception.
        /// </summary>
        /// <param name="ex"> The exception. </param>
        private static void LogAndDisplayException(Exception ex)
        {
            Logger.Get.Error(ex.Message, ex);
            var message = String.Format("Hi! We are sorry, but the an exception occured. The application will now terminate, see log for details. " +
                "Your Video Wall team.");

            // Search recursive for an inner exception of type type VideoWallException
            var innerException = ex;
            while (innerException.InnerException!= null && !(innerException is VideoWallException)) innerException = innerException.InnerException;

            var videoWallException = innerException as VideoWallException;
            if (videoWallException == null && ex.InnerException != null) videoWallException = ex.InnerException as VideoWallException;
            if (videoWallException != null) message += String.Format("\n\nMessage: {0}", videoWallException.Message);

            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}