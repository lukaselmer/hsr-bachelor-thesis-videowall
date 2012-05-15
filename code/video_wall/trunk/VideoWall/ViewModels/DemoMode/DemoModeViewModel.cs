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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Common;
using ServiceModels.Player;
using ViewModels.Menu;

#endregion

namespace ViewModels.DemoMode
{
    public class DemoModeViewModel : Notifier
    {
        private readonly Player _player;
        private readonly Random _random;
        private int _countdown;
        private Color _currentColor;
        private bool _isCountDownVisible;
        private bool _isTextVisible;
        private Visibility _visibility;

        public DemoModeViewModel(Player player, MenuViewModel menuViewModel)
        {
            InitColors();
            ModeTimer = new ModeTimer();
            ModeTimer.InteractionModeTimer.Tick += OnInteractionModeTimerTick;
            ModeTimer.DemoModeTimer.Tick += OnDemoModeTimerTick;
            ModeTimer.SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            DemomodeText = menuViewModel.CurrentApp.DemomodeText;
            _player = player;
            _player.PropertyChanged += OnPlayerChanged;
            _random = new Random();
            Countdown = ModeTimer.DemoModeTimer.GetIntervalSeconds();
            IsCountDownVisible = false;
            IsTextVisible = false;
            Visibility = Visibility.Collapsed;
        }


        public Visibility Visibility
        {
            get { return _visibility; }
            private set
            {
                _visibility = value;
                Notify("Visibility");
            }
        }

        public bool IsCountDownVisible
        {
            get { return _isCountDownVisible; }
            private set
            {
                _isCountDownVisible = value;
                Notify("IsCountDownVisible");
            }
        }

        public bool IsTextVisible
        {
            get { return _isTextVisible; }
            private set
            {
                _isTextVisible = value;
                Notify("IsTextVisible");
            }
        }

        /// <summary>
        /// Gets the text to be displayed.
        /// </summary>
        public string DemomodeText { get; private set; }


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

        public int Countdown
        {
            get { return _countdown; }
            private set
            {
                _countdown = value;
                Notify("Countdown");
            }
        }

        public ModeTimer ModeTimer { get; set; }

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
            Visibility = Visibility.Collapsed;
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            ChangeColor();
            Visibility = Visibility.Visible;
            IsCountDownVisible = false;
            IsTextVisible = true;
        }

        private void InitColors()
        {
            Colors = new List<Color> { Color.FromRgb(0, 98, 158), Color.FromRgb(200, 0, 89), Color.FromRgb(132, 181, 16), Color.FromRgb(242, 144, 0) };
            CurrentColor = Colors.First();
        }

        private void ChangeColor()
        {
            CurrentColor = Colors[_random.Next(0, Colors.Count)];
        }
    }
}