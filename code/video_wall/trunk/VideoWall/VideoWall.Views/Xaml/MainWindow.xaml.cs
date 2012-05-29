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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using VideoWall.ServiceModels.HandCursor;
using VideoWall.ViewModels.Cursor;
using VideoWall.ViewModels.HitButton;
using VideoWall.ViewModels.Main;
using VideoWall.Views.Helpers;

#endregion

namespace VideoWall.Views.Xaml
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Declarations

        /// <summary>
        ///   The time which the cursor has to stay on a button until a click is executed.
        /// </summary>
        private const double Interval = 1500;

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
            RegisterMouseMoveMethodsForMouseCursorViewModel();
            InitializeComponent();
            InitHitTestHelper();
            InitStoryboard();
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
            _hitTestHelper = new HitTestHelper(MainWindowViewModel.CursorViewModel, this, Interval) {HitElements = elements};
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
            Closing += (sender, args) => MouseMove -= updateMousePosition;
        }

        #endregion
    }
}