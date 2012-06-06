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
using VideoWall.ServiceModels.DemoMode.Interfaces;

#endregion

namespace VideoWall.ServiceModels.DemoMode.Implementation
{
    /// <summary>
    ///   The mode timer
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class DemoModeStateTimers
    {
        #region Declarations

        /// <summary>
        ///   The auto app change timer changes the app periodically in the demo mode.
        /// </summary>
        private readonly EnhancedDispatcherTimer _autoAppChangeTimer; //TODO: stop this timer?

        /// <summary>
        ///   The demo mode configuration
        /// </summary>
        private readonly IDemoModeConfig _demoModeConfig;

        /// <summary>
        ///   The time when the countdown was started the last time.
        /// </summary>
        private DateTime _countdownStartedAt;

        /// <summary>
        ///   The demo mode state check timer checks periodically if the state should change based on the time the last skeleton was tracked.
        /// </summary>
        private EnhancedDispatcherTimer _demoModeStateCheckTicker; //TODO: stop this timer?

        /// <summary>
        ///   The date time when the last skeleton appeared
        /// </summary>
        private DateTime _lastSkeletonTime;

        /// <summary>
        ///   The current state of the video wall
        /// </summary>
        private VideoWallState _state;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the countdown.
        /// </summary>
        public int Countdown
        {
            get
            {
                var cts = _demoModeConfig.CountdownTimeSpan;
                var seconds = (int)cts.Subtract(DateTime.Now.Subtract(_countdownStartedAt)).TotalSeconds;
                if (seconds < 0 || seconds > cts.Seconds) seconds = cts.Seconds;
                return seconds + 1;
            }
        }

        /// <summary>
        ///   Gets the state.
        /// </summary>
        public VideoWallState State
        {
            get { return _state; }
            private set
            {
                if (_state == value) return;
                _state = value;
                if (_state == VideoWallState.Teaser) _autoAppChangeTimer.Start();
                if (_state == VideoWallState.Countdown) _autoAppChangeTimer.Stop();
                DemoModeStateChanged(this, null);
            }
        }

        #endregion

        #region Events

        public event EventHandler DemoModeStateChanged = delegate { };
        public event EventHandler AppChanged = delegate { };
        public event EventHandler CountdownChanged = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="DemoModeStateTimers" /> class.
        /// </summary>
        internal DemoModeStateTimers(IDemoModeConfig demoModeConfig)
        {
            _demoModeConfig = demoModeConfig;

            // TODO: stop the timers
            _autoAppChangeTimer = new EnhancedDispatcherTimer(AppChangedMethod, _demoModeConfig.ChangeAppTimeSpan);
            _demoModeStateCheckTicker = new EnhancedDispatcherTimer(CheckAndChangeState, _demoModeConfig.SkeletonCheckTimeSpan, true);

            _lastSkeletonTime = DateTime.Now;
            State = VideoWallState.Active;
        }

        #endregion

        #region Methods

        private void AppChangedMethod(object sender, EventArgs args)
        {
            AppChanged(sender, args);
        }

        /// <summary>
        /// Checks and changes the state based on the time of the last skeleton.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckAndChangeState(object sender, EventArgs e)
        {
            switch (State)
            {
                case VideoWallState.Active:
                    if (!SkeletonTrackedWithin(_demoModeConfig.FromActiveToDemoModeTimeSpan))
                    {
                        State = VideoWallState.Teaser;
                    }
                    break;
                case VideoWallState.Teaser:
                    if (SkeletonTrackedWithin(_demoModeConfig.SkeletonTrackingTimeoutTimeSpan))
                    {
                        _countdownStartedAt = DateTime.Now;
                        State = VideoWallState.Countdown;
                    }
                    break;
                case VideoWallState.Countdown:
                    CountdownChanged(this, null);
                    if (!SkeletonTrackedWithin(_demoModeConfig.SkeletonTrackingTimeoutTimeSpan))
                    {
                        State = VideoWallState.Teaser;
                    }
                    else
                    {
                        if (DateTime.Now.Subtract(_countdownStartedAt) > _demoModeConfig.CountdownTimeSpan)
                        {
                            State = VideoWallState.Active;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Wether the skeleton was tracked within a certain time span.
        /// </summary>
        /// <param name="ago">The ago.</param>
        /// <returns></returns>
        private bool SkeletonTrackedWithin(TimeSpan ago)
        {
            return DateTime.Now.Subtract(_lastSkeletonTime) < ago;
        }

        /// <summary>
        ///   The skeleton changed.
        /// </summary>
        internal void SkeletonChanged()
        {
            _lastSkeletonTime = DateTime.Now;
        }

        #endregion
    }
}
