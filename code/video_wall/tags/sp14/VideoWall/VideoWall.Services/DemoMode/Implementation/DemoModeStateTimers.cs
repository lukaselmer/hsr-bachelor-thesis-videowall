﻿#region Header

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
    internal class DemoModeStateTimers
    {
        #region Declarations

        /// <summary>
        /// The demo mode configuration
        /// </summary>
        private readonly IDemoModeConfig _demoModeConfig;

        /// <summary>
        /// The date time when the last skeleton appeared
        /// </summary>
        private DateTime _lastSkeletonTime;

        private EnhancedDispatcherTimer _demoModeStateCheckTicker;
        private readonly EnhancedDispatcherTimer _autoAppChangeTimer;

        private VideoWallState _state;
        private DateTime _countdownStartedAt;

        #endregion

        #region Properties

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

        public VideoWallState State
        {
            get { return _state; }
            private set
            {
                if (_state == value) return;
                _state = value;
                if (_state == VideoWallState.Teaser) _autoAppChangeTimer.Start();
                if (_state == VideoWallState.Countdown) _autoAppChangeTimer.Stop();
                OnDemoModeStateChange(this, new EventArgs());
            }
        }

        #endregion

        #region Events

        public event EventHandler<EventArgs> OnDemoModeStateChange = delegate { };
        public event EventHandler<EventArgs> OnAppChange = delegate { };
        public event EventHandler<EventArgs> OnCountdownChange = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="DemoModeStateTimers" /> class.
        /// </summary>
        internal DemoModeStateTimers(IDemoModeConfig demoModeConfig)
        {
            _demoModeConfig = demoModeConfig;
            State = VideoWallState.Active;

            // TODO: stop the timers
            _demoModeStateCheckTicker = new EnhancedDispatcherTimer(CheckState, _demoModeConfig.SkeletonCheckTimeSpan, true);
            _autoAppChangeTimer = new EnhancedDispatcherTimer(AppChanged, _demoModeConfig.ChangeAppTimeSpan);
        }

        private void AppChanged(object sender, EventArgs e)
        {
            OnAppChange(sender, e);
        }

        private void CheckState(object sender, EventArgs e)
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
                    OnCountdownChange(this, new EventArgs());
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