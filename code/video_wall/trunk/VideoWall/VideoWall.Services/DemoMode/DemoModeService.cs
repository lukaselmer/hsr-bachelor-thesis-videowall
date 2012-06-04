﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using VideoWall.Common.Extensions;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode service
    /// </summary>
    public class DemoModeService
    {
        #region Declarations

        /// <summary>
        /// The player
        /// </summary>
        private readonly Player.Player _player;

        /// <summary>
        /// The demo mode config
        /// </summary>
        private readonly DemoModeConfig _demoModeConfig;

        /// <summary>
        /// The mode timer realizes a state machine for the demo mode
        /// </summary>
        private ModeTimer _modeTimer;

        /// <summary>
        /// The current state of the demo mode
        /// </summary>
        private DemoModeState _state = DemoModeState.Inactive;

        /// <summary>
        /// The countdown
        /// </summary>
        private int _countdown;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public DemoModeState State
        {
            get { return _state; }
            private set
            {
                if (_state == value) return;
                _state = value;
                DemoModeStateChanged(this, new DemoModeStateChangedEventArgs(_state));
            }
        }

        /// <summary>
        /// Gets or sets the color of the current.
        /// </summary>
        /// <value>
        /// The color of the current.
        /// </value>
        public Color CurrentColor { get; private set; }

        /// <summary>
        /// Gets the countdown.
        /// </summary>
        public int Countdown
        {
            get { return _countdown; }
            private set
            {
                if (_countdown == value) return;
                _countdown = value;
                DemoModeCountdownChanged(this, new DemoModeCountdownChangedEventArgs());
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// Occurs when demo mode state changed.
        /// </summary>
        public event DemoModeStateChangedEvent DemoModeStateChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        public event DemoModeAppChangedEvent DemoModeAppChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        public event DemoModeColorChangedEvent DemoModeColorChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode countdown changed.
        /// </summary>
        public event DemoModeCountdownChangedEvent DemoModeCountdownChanged = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeService"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="demoModeConfig">The demo mode config.</param>
        public DemoModeService(Player.Player player, DemoModeConfig demoModeConfig)
        {
            _player = player;
            _demoModeConfig = demoModeConfig;

            ChangeColorAndApp();
            InitModeTimer();

            player.PropertyChanged += OnPlayerChanged;
        }

        #endregion

        #region Methods

        private void OnPlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_player.Skeleton != null) _modeTimer.SkeletonChanged();
        }

        private void InitModeTimer()
        {
            _modeTimer = new ModeTimer(_demoModeConfig);
            _modeTimer.ToDemoModeTimer.Tick += OnToDemoModeTimerTick;
            _modeTimer.ToInteractionModeTimer.Tick += OnToInteractionModeTimerTick;
            _modeTimer.SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            _modeTimer.FastSkeletonCheckTimer.Tick += OnFastSkeletonCheckTimerTick;
            _modeTimer.ChangeAppTimer.Tick += OnChangeAppTimerTick;
        }

        private void OnFastSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!_modeTimer.WasSkeletonChanged()) return;
            State = DemoModeState.Countdown;
        }

        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (!_modeTimer.IsInInteractionMode)
            {
                if (_modeTimer.WasSkeletonChanged())
                {
                    Countdown -= _modeTimer.SkeletonCheckTimer.GetIntervalSeconds();
                }
                else
                {
                    Countdown = _modeTimer.ToInteractionModeTimer.GetIntervalSeconds();
                    State = DemoModeState.Teaser;
                }
            }
        }

        private void OnToInteractionModeTimerTick(object sender, EventArgs e)
        {
            State = DemoModeState.Inactive;
        }

        private void OnToDemoModeTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
            State = DemoModeState.Teaser;
            Countdown = _modeTimer.ToInteractionModeTimer.GetIntervalSeconds();
        }

        private void ChangeColorAndApp()
        {
            CurrentColor = _demoModeConfig.BackgroundColors.RandomElement();
            DemoModeColorChanged(this, new DemoModeColorChangedEventArgs());
            DemoModeAppChanged(this, new DemoModeAppChangedEventArgs());
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
        }

        #endregion
    }
}