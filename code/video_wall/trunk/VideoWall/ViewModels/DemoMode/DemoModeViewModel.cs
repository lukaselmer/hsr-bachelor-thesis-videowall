using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Common;
using ServiceModels.Player;

namespace ViewModels.DemoMode
{
    public class DemoModeViewModel : Notifier
    {
        private readonly Random _random;
        private Color _currentColor;
        private bool _isVisible;
        private readonly Player _player;

        public DemoModeViewModel(Player player)
        {
            InitColors();
            ModeTimer = new ModeTimer();
            ModeTimer.InteractionModeTimer.Tick += OnInteractionModeTimerTick;
            ModeTimer.DemoModeTimer.Tick += OnDemoModeTimerTick;
            ModeTimer.SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            _player = player;
            _player.PropertyChanged += OnPlayerChanged;
            _random = new Random();
            Countdown = ModeTimer.DemoModeTimer.GetIntervalSeconds();
            IsCountDownVisible = false;
            IsTextVisible = false;
        }

        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!ModeTimer.IsInInteractionMode)
            {
                if (ModeTimer.WasSkeletonChanged())
                {
                    IsCountDownVisible = true;
                    IsTextVisible = false;
                    Countdown -= ModeTimer.SkeletonCheckTimer.GetIntervalSeconds();
                }
                else
                {
                    Countdown = ModeTimer.DemoModeTimer.GetIntervalSeconds();
                    IsCountDownVisible = false;
                    IsTextVisible = true;
                }
            }
        }

        private void OnPlayerChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_player.Skeleton != null) ModeTimer.SkeletonChanged();
        }

        private void OnDemoModeTimerTick(object sender, EventArgs e)
        {
            IsVisible = false;
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            ChangeColor();
            IsVisible = true;
            IsCountDownVisible = false;
            IsTextVisible = true;
        }

        private void InitColors()
        {
            var blue = new Color() { R = 0, G = 98, B = 158, A = 255 };
            var pink = new Color() { R = 200, G = 0, B = 89, A = 255 };
            var green = new Color() { R = 132, G = 181, B = 16, A = 255 };
            var orange = new Color() { R = 242, G = 144, B = 0, A = 255 };
            Colors = new List<Color>() { blue, pink, green, orange };
            CurrentColor = Colors.First();
            IsVisible = false;
        }


        public bool IsVisible { get { return _isVisible; }
            private set
            {
                _isVisible = value;
                Notify("IsVisible");
            } }

        private bool _isCountDownVisible;
        public bool IsCountDownVisible { get { return _isCountDownVisible; } private set
        {
            _isCountDownVisible = value;
            Notify("IsCountDownVisible");
        } }

        private bool _isTextVisible;
        public bool IsTextVisible { get { return _isTextVisible; } private set
        {
            _isTextVisible = value;
            Notify("IsTextVisible");
        } }

        private List<Color> Colors { get; set; }


        public Color CurrentColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                Notify("CurrentColor");
            }
        }

        private int _countdown;
        public int Countdown { get { return _countdown; }
            private set {
                _countdown = value;
                Notify("Countdown");
        } }

        public ModeTimer ModeTimer { get; set; }

        private void ChangeColor()
        {
            CurrentColor = Colors[_random.Next(0, Colors.Count)];
        }
    }
}
