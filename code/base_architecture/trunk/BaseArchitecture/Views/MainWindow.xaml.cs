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

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = MainWindowViewModel = mainWindowViewModel;
            RegisterMouseMoveMethodsForMouseCursorViewModel();
            InitializeComponent();
            InitHitTestHelper();
            InitStoryboard();
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }
        private void InitStoryboard()
        {
            _storyboard = CursorAmimation.InitStoryboard(Interval);
        }

        private void InitHitTestHelper()
        {
            var elements = ExtendedVisualTreeHelper.FindInVisualTreeDown<Button>(MainContainer);
            _hitTestHelper = new HitTestHelper(MainWindowViewModel.CursorViewModel, this, Interval) { HitElements = elements };
            _hitTestHelper.Started += StartAnimation;
            _hitTestHelper.Stopped += StopAnimation;
            _hitTestHelper.Clicked += ButtonClicked;
        }
        private void ButtonClicked(object sender, HitStateArgs args)
        {
            StartAnimation(sender, args);
            var button = args.UIElement as Button;
            if (button != null) RaiseEventOfUIElement(button);
        }
        private void RaiseEventOfUIElement(Button uiElement)
        {
            var peer = new ButtonAutomationPeer(uiElement);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            Debug.Assert(invokeProv != null, "invokeProv != null");
            invokeProv.Invoke();
        }

        private void StopAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Stop(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Hidden;
        }

        private void StartAnimation(object sender, HitStateArgs args)
        {
            _storyboard.Begin(CursorAmimation);
            CursorAmimation.Visibility = Visibility.Visible;
        }

        private void RegisterMouseMoveMethodsForMouseCursorViewModel()
        {
            var mouseCursorViewModel = MainWindowViewModel.CursorViewModel as MouseCursorViewModel;
            if (mouseCursorViewModel == null) return;

            MouseEventHandler updateMousePosition = (sender, args) => mouseCursorViewModel.Position = args.GetPosition(this);
            MouseMove += updateMousePosition;
            Closing += (sender, args) => MouseMove -= updateMousePosition;
        }
    }
}
