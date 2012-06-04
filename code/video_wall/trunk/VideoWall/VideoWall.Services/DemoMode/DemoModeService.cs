using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using VideoWall.Common.Extensions;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.DemoMode.EventObjects;

namespace VideoWall.ServiceModels.DemoMode
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
        private readonly Player.Player _player;

        /// <summary>
        /// The demo mode config
        /// </summary>
        private readonly IDemoModeConfig _demoModeConfig;

        /// <summary>
        /// The mode timer realizes a state machine for the demo mode
        /// </summary>
        private readonly DemoModeStateTimers _demoModeStateTimers;

        /// <summary>
        /// The current state of the demo mode
        /// </summary>
        private DemoModeState _state = DemoModeState.Inactive;

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
            get { return _demoModeStateTimers.State; }
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
            get { return _demoModeStateTimers.Countdown; }
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
        public DemoModeService(Player.Player player, IDemoModeConfig demoModeConfig)
        {
            _player = player;
            _demoModeConfig = demoModeConfig;

            ChangeColorAndApp();
            _demoModeStateTimers = new DemoModeStateTimers(_demoModeConfig);
            _demoModeStateTimers.OnDemoModeStateChange += OnDemoModeStateChange;
            _demoModeStateTimers.OnAppChange += OnChangeAppTimerTick;
            _demoModeStateTimers.OnCountdownChange += OnCountdownChange;

            player.PropertyChanged += OnPlayerChanged;
        }

        private void OnCountdownChange(object sender, EventArgs e)
        {
            DemoModeCountdownChanged(this, new DemoModeCountdownChangedEventArgs());
        }

        #endregion

        #region Methods

        private void OnPlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_player.Skeleton != null) _demoModeStateTimers.SkeletonChanged();
        }

        private void OnDemoModeStateChange(object sender, EventArgs e)
        {
            DemoModeStateChanged(this, new DemoModeStateChangedEventArgs(State));
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
