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
using VideoWall.Common.Extensions;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player;
using VideoWall.ViewModels.Menu;
using VideoWall.ViewModels.Skeletton;

#endregion

// TODO: insert regions

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
        private readonly DemoModeConfig _demoModeConfig;
        private int _countdown;

        private Color _currentColor;

        private DemoModeState _state = DemoModeState.Inactive;

        private readonly MenuViewModel _menuViewModel;
        private readonly PlayerViewModel _playerViewModel;


        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="menuViewModel">The menu view model.</param>
        /// <param name="playerViewModel">The player view model.</param>
        /// <param name="demoModeConfig">The demo mode config.</param>
        public DemoModeViewModel(Player player, MenuViewModel menuViewModel, PlayerViewModel playerViewModel, DemoModeConfig demoModeConfig)
        {
            //TODO: test preconditions

            _demoModeConfig = demoModeConfig;

            _player = player;
            _player.PropertyChanged += OnPlayerChanged;

            _menuViewModel = menuViewModel;
            _menuViewModel.PropertyChanged += (sender, args) => Notify("DemoModeText");

            _playerViewModel = playerViewModel;
            _playerViewModel.WidthAndHeight = 500; //TODO: use relative value

            ChangeColorAndApp();
            InitModeTimer();

            Countdown = ModeTimer.ToInteractionModeTimer.GetIntervalSeconds();
        }

        /// <summary>
        ///   Gets or sets the player view model.
        /// </summary>
        /// <value> The player view model. </value>
        public PlayerViewModel PlayerViewModel { get { return _playerViewModel; } }

        /// <summary>
        /// Gets or sets the state of the demo mode.
        /// </summary>
        /// <value>
        /// The demo mode state.
        /// </value>
        private DemoModeState State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;

                _state = value;

                Notify("DemoModeVisibility");
                Notify("CountDownVisibility");
                Notify("TeaserVisibility");
            }
        }

        /// <summary>
        ///   Gets the visibility.
        /// </summary>
        public Visibility DemoModeVisibility
        {
            get { return State == DemoModeState.Inactive ? Visibility.Collapsed : Visibility.Visible; }
        }

        /// <summary>
        ///   Gets a value indicating whether the countdown is visible or not.
        /// </summary>
        public Visibility CountDownVisibility
        {
            get { return State == DemoModeState.Countdown ? Visibility.Visible : Visibility.Collapsed; }
        }

        /// <summary>
        ///   Gets a value indicating whether the text is visible or not.
        /// </summary>
        public Visibility TeaserVisibility
        {
            get { return State == DemoModeState.Teaser ? Visibility.Visible : Visibility.Collapsed; }
        }

        /// <summary>
        /// Gets the teaser text.
        /// </summary>
        public string TeaserText
        {
            get { return _menuViewModel.CurrentApp.App.DemomodeText; }
        }

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
            ModeTimer = new ModeTimer(_demoModeConfig);
            ModeTimer.ToDemoModeTimer.Tick += OnToDemoModeTimerTick;
            ModeTimer.ToInteractionModeTimer.Tick += OnToInteractionModeTimerTick;
            ModeTimer.SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            ModeTimer.FastSkeletonCheckTimer.Tick += OnFastSkeletonCheckTimerTick;
            ModeTimer.ChangeAppTimer.Tick += OnChangeAppTimerTick;
        }

        private void OnFastSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!ModeTimer.WasSkeletonChanged()) return;
            State = DemoModeState.Countdown;
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
                    State = DemoModeState.Teaser;
                }
            }
        }

        private void OnPlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_player.Skeleton != null) ModeTimer.SkeletonChanged();
        }

        private void OnToInteractionModeTimerTick(object sender, EventArgs e)
        {
            State = DemoModeState.Inactive;
        }

        private void OnToDemoModeTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
            State = DemoModeState.Teaser;
            Countdown = ModeTimer.ToInteractionModeTimer.GetIntervalSeconds();
        }

        private void ChangeColorAndApp()
        {
            CurrentColor = _demoModeConfig.BackgroundColors.RandomElement();
            _menuViewModel.ChangeToRandomApp();
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
        }
    }
}