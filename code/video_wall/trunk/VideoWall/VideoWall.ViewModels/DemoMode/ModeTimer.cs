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
using System.Windows.Threading;

#endregion

namespace VideoWall.ViewModels.DemoMode
{
    /// <summary>
    ///   The mode timer
    /// </summary>
    public class ModeTimer
    {
        private TimeSpan _changeAppTimeSpan;
        private TimeSpan _fastSkeletonTimeSpan;

        private DateTime _lastSkeletonTime;
        private TimeSpan _skeletonCheckTimeSpan;
        private TimeSpan _toDemoModeTimeSpan;
        private TimeSpan _toInteractionModeTimeSpan;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ModeTimer" /> class.
        /// </summary>
        public ModeTimer()
        {
            InitToDemoModeTimer();
            InitToInteractionModeTimer();
            InitSkeletonCheckTimer();
            InitChangeAppTimer();
            InitFastSkeletonCheckTimer();

            IsInInteractionMode = true;
        }

        #region Properties

        /// <summary>
        ///   Gets the demo mode timer.
        /// </summary>
        public DispatcherTimer ToInteractionModeTimer { get; private set; }

        /// <summary>
        ///   Gets the fast skeleton check timer.
        /// </summary>
        public DispatcherTimer FastSkeletonCheckTimer { get; private set; }

        /// <summary>
        ///   Gets the interaction mode timer.
        /// </summary>
        public DispatcherTimer ToDemoModeTimer { get; private set; }

        /// <summary>
        ///   Gets the skeleton check timer.
        /// </summary>
        public DispatcherTimer SkeletonCheckTimer { get; private set; }

        /// <summary>
        ///   Gets the change app timer.
        /// </summary>
        public DispatcherTimer ChangeAppTimer { get; private set; }

        /// <summary>
        ///   Gets a value indicating whether this instance is in interaction mode.
        /// </summary>
        public bool IsInInteractionMode { get; private set; }

        #endregion

        private void InitToInteractionModeTimer()
        {
            _toInteractionModeTimeSpan = TimeSpan.FromSeconds(5);
            ToInteractionModeTimer = new DispatcherTimer {Interval = _toInteractionModeTimeSpan};
            ToInteractionModeTimer.Tick += OnToInteractionModeTimerTick;
        }

        private void InitToDemoModeTimer()
        {
            _toDemoModeTimeSpan = TimeSpan.FromSeconds(10);
            ToDemoModeTimer = new DispatcherTimer {Interval = _toDemoModeTimeSpan};
            ToDemoModeTimer.Tick += OnToDemoModeTimerTick;
            ToDemoModeTimer.Start();
        }


        private void InitFastSkeletonCheckTimer()
        {
            _fastSkeletonTimeSpan = TimeSpan.FromMilliseconds(10);
            FastSkeletonCheckTimer = new DispatcherTimer {Interval = _fastSkeletonTimeSpan};
            FastSkeletonCheckTimer.Tick += OnFastSkeletonCheckTimerTick;
        }

        private void InitSkeletonCheckTimer()
        {
            _skeletonCheckTimeSpan = TimeSpan.FromSeconds(1);
            SkeletonCheckTimer = new DispatcherTimer {Interval = _skeletonCheckTimeSpan};
            SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            SkeletonCheckTimer.Start();
        }

        private void InitChangeAppTimer()
        {
            _changeAppTimeSpan = TimeSpan.FromSeconds(20);
            ChangeAppTimer = new DispatcherTimer {Interval = _changeAppTimeSpan};
            ChangeAppTimer.Tick += OnChangeAppTimerTick;
        }

        private void OnToInteractionModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = true;

            ToDemoModeTimer.Start();
            ToInteractionModeTimer.Stop();

            SkeletonCheckTimer.Stop();
            FastSkeletonCheckTimer.Start();

            ChangeAppTimer.Stop();
        }

        private void OnToDemoModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;

            ToInteractionModeTimer.Start();
            ToDemoModeTimer.Stop();

            SkeletonCheckTimer.Start();
            FastSkeletonCheckTimer.Stop();

            ChangeAppTimer.Start();
        }

        private void OnFastSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (WasSkeletonChanged())
            {
                SkeletonCheckTimer.Start();
                FastSkeletonCheckTimer.Stop();
            }
            else
            {
                ToInteractionModeTimer.Reset();
            }
        }

        /// <summary>
        ///   Called when skeleton check timer tickes.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.EventArgs" /> instance containing the event data. </param>
        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (IsInInteractionMode)
            {
                if (WasSkeletonChanged())
                {
                    ToDemoModeTimer.Reset();
                }
            }
            else
            {
                if (WasSkeletonChanged())
                {
                    ChangeAppTimer.Reset();
                }
                else
                {
                    ToInteractionModeTimer.Reset();
                    FastSkeletonCheckTimer.Start();
                    SkeletonCheckTimer.Stop();
                }
            }
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeAppTimer.Reset();
        }

        /// <summary>
        ///   Wether the skeleton was changed.
        /// </summary>
        /// <returns> </returns>
        public bool WasSkeletonChanged()
        {
            return _lastSkeletonTime.Add(_skeletonCheckTimeSpan) > DateTime.Now;
        }

        /// <summary>
        ///   The skeleton changed.
        /// </summary>
        public void SkeletonChanged()
        {
            _lastSkeletonTime = DateTime.Now;
        }
    }
}