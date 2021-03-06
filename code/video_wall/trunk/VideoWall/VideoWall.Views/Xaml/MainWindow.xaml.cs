﻿#region Header

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
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using VideoWall.Common.Logging;
using VideoWall.ViewModels.Cursor;
using VideoWall.ViewModels.HitButton;
using VideoWall.ViewModels.Main;
using VideoWall.Views.Helpers;
using Application = System.Windows.Application;
using Button = System.Windows.Controls.Button;
using Cursors = System.Windows.Input.Cursors;
using MouseEventHandler = System.Windows.Input.MouseEventHandler;
using Timer = System.Threading.Timer;

#endregion

namespace VideoWall.Views.Xaml
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Declarations

        private static readonly TimeSpan Interval = TimeSpan.FromMilliseconds(1500);

        private HitTestHelper _hitTestHelper;

        private Storyboard _storyboard;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <param name="mainWindowViewModel"> The main window view model. </param>
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = MainWindowViewModel = mainWindowViewModel;
            InitShutdownRoutine();
            RegisterMouseMoveMethodsForMouseCursorViewModel();
            InitializeComponent();
            InitHitTestHelper();
            InitStoryboard();
            MaximizeWindowOverMultipleScreens();
        }
        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the main window view model.
        /// </summary>
        /// <value> The main window view model. </value>
        private MainWindowViewModel MainWindowViewModel { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///   Inits the storyboard.
        /// </summary>
        private void InitStoryboard()
        {
            _storyboard = CursorAmimation.InitStoryboard(Interval);
        }

        /// <summary>
        ///   Inits the hit test helper.
        /// </summary>
        private void InitHitTestHelper()
        {
            var elements = ExtendedVisualTreeHelper.FindInVisualTreeDown<Button>(MainContainer);
            _hitTestHelper = new HitTestHelper(MainWindowViewModel.CursorViewModel, this, Interval) { HitElements = elements };
            _hitTestHelper.Started += StartAnimation;
            _hitTestHelper.Stopped += StopAnimation;
            _hitTestHelper.Clicked += ButtonClicked;
        }

        /// <summary>
        ///   Performs click on Button.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The arguments. </param>
        private void ButtonClicked(object sender, HitStateArgs args)
        {
            StartAnimation(sender, args);
            var button = args.UIElement as Button;
            if (button != null) button.SimulateClick();
        }

        /// <summary>
        ///   Stops the animation.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The arguments. </param>
        private void StopAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Stop(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///   Starts the animation.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The arguments. </param>
        private void StartAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Begin(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///   Registers the mouse move methods for mouse cursor view model.
        /// </summary>
        private void RegisterMouseMoveMethodsForMouseCursorViewModel()
        {
            var mouseCursorViewModel = MainWindowViewModel.CursorViewModel as MouseCursorViewModel;
            if (mouseCursorViewModel == null) return;

            MouseEventHandler updateMousePosition = (sender, args) => mouseCursorViewModel.Position = args.GetPosition(this);
            MouseMove += updateMousePosition;
            Cursor = Cursors.None;
            Closing += (sender, args) => MouseMove -= updateMousePosition;
        }

        /// <summary>
        /// Maximizes the window over multiple screens.
        /// </summary>
        private void MaximizeWindowOverMultipleScreens()
        {
            Left = Screen.AllScreens.Min(screen => screen.Bounds.X);
            Top = Screen.AllScreens.Min(screen => screen.Bounds.Y);
            Width =  Screen.AllScreens.Max(screen => screen.Bounds.X + screen.Bounds.Width) - Left;
            Height = Screen.AllScreens.Max(screen => screen.Bounds.Y + screen.Bounds.Height) - Top;
        }

        private void InitShutdownRoutine()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Closing += delegate
            {
                Logger.Get.Info("Shutdown initiated.");
                // If the application cannot shut down properly, ensure that everything is stopped eventually (after 4000 milliseconds).
                new Timer(state => Process.GetCurrentProcess().Kill(), null, 4000, Timeout.Infinite);
            };
        }

        #endregion
    }
}