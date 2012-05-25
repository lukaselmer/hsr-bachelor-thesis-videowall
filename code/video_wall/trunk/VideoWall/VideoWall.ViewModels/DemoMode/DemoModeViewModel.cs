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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using VideoWall.Common;
using VideoWall.ServiceModels.Player;
using VideoWall.ViewModels.Menu;
using VideoWall.ViewModels.Skeletton;

#endregion

namespace VideoWall.ViewModels.DemoMode
{
    /// <summary>
    ///   The DemoModeViewModel
    /// </summary>
// ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong
    public class DemoModeViewModel : Notifier
// ReSharper restore ClassNeverInstantiated.Global
    {
        private readonly Player _player;
        private readonly Random _random = new Random();
        private int _countdown;
        private Color _currentColor;
        private bool _isCountDownVisible;
        private bool _isTextVisible;
        private Visibility _visibility = Visibility.Collapsed;

        /// <summary>
        ///   Initializes a new instance of the <see cref="DemoModeViewModel" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        /// <param name="menuViewModel"> The menu view model. </param>
        /// <param name="playerViewModel"> </param>
        public DemoModeViewModel(Player player, MenuViewModel menuViewModel, PlayerViewModel playerViewModel)
        {
            InitColors();
            InitModeTimer();

            _player = player;
            _player.PropertyChanged += OnPlayerChanged;

            MenuViewModel = menuViewModel;

            PlayerViewModel = playerViewModel;
            PlayerViewModel.WidthAndHeight = 600; //TODO: use relative value

            Countdown = ModeTimer.ToInteractionModeTimer.GetIntervalSeconds();
        }


        /// <summary>
        ///   Gets or sets the player view model.
        /// </summary>
        /// <value> The player view model. </value>
        public PlayerViewModel PlayerViewModel { get; set; }


        /// <summary>
        ///   Gets the visibility.
        /// </summary>
        public Visibility Visibility
        {
            get { return _visibility; }
            private set
            {
                _visibility = value;
                Notify("Visibility");
            }
        }

        /// <summary>
        ///   Gets a value indicating whether the countdown is visible or not.
        /// </summary>
        public bool IsCountDownVisible
        {
            get { return _isCountDownVisible; }
            private set
            {
                _isCountDownVisible = value;
                Notify("IsCountDownVisible");
            }
        }

        /// <summary>
        ///   Gets a value indicating whether the text is visible or not.
        /// </summary>
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
        ///   Gets or sets the MenuViewModel.
        /// </summary>
        public MenuViewModel MenuViewModel { get; set; }

        private List<Color> Colors { get; set; }

        /// <summary>
        ///   Gets or sets the current color.
        /// </summary>
        public Color CurrentColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                Notify("CurrentColor");
            }
        }

        /// <summary>
        ///   Gets the Countdown.
        /// </summary>
        public int Countdown
        {
            get { return _countdown; }
            private set
            {
                _countdown = value;
                Notify("Countdown");
            }
        }

        /// <summary>
        ///   Gets or sets the ModeTimer.
        /// </summary>
        private ModeTimer ModeTimer { get; set; }

        private void InitModeTimer()
        {
            ModeTimer = new ModeTimer();
            ModeTimer.ToDemoModeTimer.Tick += OnToDemoModeTimerTick;
            ModeTimer.ToInteractionModeTimer.Tick += OnToInteractionModeTimerTick;
            ModeTimer.SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            ModeTimer.FastSkeletonCheckTimer.Tick += OnFastSkeletonCheckTimerTick;
            ModeTimer.ChangeAppTimer.Tick += OnChangeAppTimerTick;
        }

        private void OnFastSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!ModeTimer.WasSkeletonChanged()) return;
            IsCountDownVisible = true;
            IsTextVisible = false;
        }

        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!ModeTimer.IsInInteractionMode)
            {
                if (ModeTimer.WasSkeletonChanged())
                {
                    Countdown -= ModeTimer.SkeletonCheckTimer.GetIntervalSeconds();
                }
                else
                {
                    Countdown = ModeTimer.ToInteractionModeTimer.GetIntervalSeconds();
                    IsCountDownVisible = false;
                    IsTextVisible = true;
                }
            }
        }

        private void OnPlayerChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_player.Skeleton != null) ModeTimer.SkeletonChanged();
        }

        private void OnToInteractionModeTimerTick(object sender, EventArgs e)
        {
            Visibility = Visibility.Collapsed;
            }

        private void OnToDemoModeTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
            Visibility = Visibility.Visible;
            IsCountDownVisible = false;
            IsTextVisible = true;
            Countdown = ModeTimer.ToInteractionModeTimer.GetIntervalSeconds();
        }

        private void ChangeColorAndApp()
        {
            ChangeColor();
            MenuViewModel.ChangeApp();
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
        }

        private void InitColors()
        {
            Colors = new List<Color> {Color.FromRgb(0, 98, 158), Color.FromRgb(200, 0, 89), Color.FromRgb(132, 181, 16), Color.FromRgb(242, 144, 0)};
            CurrentColor = Colors.First();
        }

        private void ChangeColor()
        {
            CurrentColor = Colors[_random.Next(0, Colors.Count)];
        }
    }
}