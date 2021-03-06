﻿using System;
using System.Windows.Media;
using VideoWall.Common.Extensions;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.DemoMode.Interfaces;
using VideoWall.ServiceModels.Player;
using VideoWall.ServiceModels.Player.Interfaces;

namespace VideoWall.ServiceModels.DemoMode.Implementation
{
    /// <summary>
    /// The demo mode service
    /// </summary>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class DemoModeService : IDemoModeService
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        /// <summary>
        /// The player
        /// </summary>
        private readonly IPlayer _player;

        /// <summary>
        /// The demo mode config
        /// </summary>
        private readonly IDemoModeConfig _demoModeConfig;

        /// <summary>
        /// The mode timer realizes a state machine for the demo mode
        /// </summary>
        private readonly DemoModeStateTimers _demoModeStateTimers;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public VideoWallState State
        {
            get { return _demoModeStateTimers.State; }
        }

        /// <summary>
        /// Gets or sets the color of the current.
        /// </summary>
        /// <value>
        /// The color of the current.
        /// </value>
        public Color CurrentBackgroundColor { get; private set; }

        /// <summary>
        /// Gets the countdown.
        /// </summary>
        public int Countdown
        {
            get { return _demoModeStateTimers.Countdown; }
        }

        #endregion

        #region Events
        /// <summary>
        /// Occurs when demo mode state changed.
        /// </summary>
        public event EventHandler DemoModeStateChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        public event EventHandler DemoModeAppChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        public event EventHandler DemoModeColorChanged = delegate { };

        /// <summary>
        /// Occurs when demo mode countdown changed.
        /// </summary>
        public event EventHandler DemoModeCountdownChanged = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeService"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="demoModeConfig">The demo mode config.</param>
        public DemoModeService(IPlayer player, IDemoModeConfig demoModeConfig)
        {
            _player = player;
            _demoModeConfig = demoModeConfig;

            ChangeColorAndApp();
            _demoModeStateTimers = new DemoModeStateTimers(_demoModeConfig);
            _demoModeStateTimers.OnDemoModeStateChange += OnDemoModeStateChange;
            _demoModeStateTimers.OnAppChange += OnChangeAppTimerTick;
            _demoModeStateTimers.OnCountdownChange += OnCountdownChange;

            player.SkeletonChanged += OnPlayerChanged;
        }

        private void OnCountdownChange(object sender, EventArgs e)
        {
            DemoModeCountdownChanged(this, null);
        }

        #endregion

        #region Methods

        private void OnPlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_player.Skeleton != null) _demoModeStateTimers.SkeletonChanged();
        }

        private void OnDemoModeStateChange(object sender, EventArgs e)
        {
            DemoModeStateChanged(this, null);
        }

        private void ChangeColorAndApp()
        {
            CurrentBackgroundColor = _demoModeConfig.BackgroundColors.RandomElement();
            DemoModeColorChanged(this, null);
            DemoModeAppChanged(this, null);
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
        }

        #endregion
    }
}
