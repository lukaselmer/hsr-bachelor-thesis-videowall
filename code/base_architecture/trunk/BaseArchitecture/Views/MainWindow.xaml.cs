using System.Diagnostics;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using ViewModels;
using ViewModels.HitButton;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const double Interval = 1500;
        private HitTestHelper _hitTestHelper;
        private Storyboard _storyboard;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="mainWindowViewModel">The main window view model.</param>
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = MainWindowViewModel = mainWindowViewModel;
            RegisterMouseMoveMethodsForMouseCursorViewModel();
            InitializeComponent();
            InitHitTestHelper();
            InitStoryboard();
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// Inits the storyboard.
        /// </summary>
        private void InitStoryboard()
        {
            _storyboard = CursorAmimation.InitStoryboard(Interval);
        }

        /// <summary>
        /// Inits the hit test helper.
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
        /// Performs click on Button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        private void ButtonClicked(object sender, HitStateArgs args)
        {
            StartAnimation(sender, args);
            var button = args.UIElement as Button;
            if (button != null) RaiseEventOfUIElement(button);
        }
        /// <summary>
        /// Raises the event of UI element.
        /// </summary>
        /// <param name="uiElement">The UI element.</param>
        private void RaiseEventOfUIElement(Button uiElement)
        {
            var peer = new ButtonAutomationPeer(uiElement);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            Debug.Assert(invokeProv != null, "invokeProv != null");
            invokeProv.Invoke();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        private void StopAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Stop(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        private void StartAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Begin(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Registers the mouse move methods for mouse cursor view model.
        /// </summary>
        private void RegisterMouseMoveMethodsForMouseCursorViewModel()
        {
            var mouseCursorViewModel = MainWindowViewModel.CursorViewModel as MouseCursorViewModel;
            if (mouseCursorViewModel == null) return;

            MouseEventHandler updateMousePosition = (sender, args) => mouseCursorViewModel.Position = args.GetPosition(this);
            MouseMove += updateMousePosition;
            Closing += (sender, args) => MouseMove -= updateMousePosition;
        }

        private void OnExit(object sender, RoutedEventArgs e) { Close(); }
    }
}
