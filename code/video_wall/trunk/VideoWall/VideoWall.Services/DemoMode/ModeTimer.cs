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

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    ///   The mode timer
    /// </summary>
    internal class ModeTimer
    {
        #region Declarations

        /// <summary>
        /// The demo mode configuration
        /// </summary>
        private readonly DemoModeConfig _demoModeConfig;

        /// <summary>
        /// The date time when the last skeleton appeared
        /// </summary>
        private DateTime _lastSkeletonTime;

        #endregion

        /// <summary>
        ///   Initializes a new instance of the <see cref="ModeTimer" /> class.
        /// </summary>
        internal ModeTimer(DemoModeConfig demoModeConfig)
        {
            _demoModeConfig = demoModeConfig;

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
        internal DispatcherTimer ToInteractionModeTimer { get; private set; }

        /// <summary>
        ///   Gets the fast skeleton check timer.
        /// </summary>
        internal DispatcherTimer FastSkeletonCheckTimer { get; private set; }

        /// <summary>
        ///   Gets the interaction mode timer.
        /// </summary>
        internal DispatcherTimer ToDemoModeTimer { get; private set; }

        /// <summary>
        ///   Gets the skeleton check timer.
        /// </summary>
        internal DispatcherTimer SkeletonCheckTimer { get; private set; }

        /// <summary>
        ///   Gets the change app timer.
        /// </summary>
        internal DispatcherTimer ChangeAppTimer { get; private set; }

        /// <summary>
        ///   Gets a value indicating whether this instance is in interaction mode.
        /// </summary>
        internal bool IsInInteractionMode { get; private set; }

        #endregion

        private void InitToDemoModeTimer()
        {
            ToDemoModeTimer = new DispatcherTimer { Interval = _demoModeConfig.ToDemoModeTimeSpan};
            ToDemoModeTimer.Tick += OnToDemoModeTimerTick;
            ToDemoModeTimer.Start();
        }

        private void InitToInteractionModeTimer()
        {
            ToInteractionModeTimer = new DispatcherTimer { Interval = _demoModeConfig.ToInteractionModeTimeSpan };
            ToInteractionModeTimer.Tick += OnToInteractionModeTimerTick;
        }

        private void InitFastSkeletonCheckTimer()
        {
            FastSkeletonCheckTimer = new DispatcherTimer { Interval = _demoModeConfig.FastSkeletonTimeSpan };
            FastSkeletonCheckTimer.Tick += OnFastSkeletonCheckTimerTick;
        }

        private void InitSkeletonCheckTimer()
        {
            SkeletonCheckTimer = new DispatcherTimer { Interval = _demoModeConfig.SkeletonCheckTimeSpan };
            SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            SkeletonCheckTimer.Start();
        }

        private void InitChangeAppTimer()
        {
            ChangeAppTimer = new DispatcherTimer { Interval = _demoModeConfig.ChangeAppTimeSpan };
        }

        private void OnToInteractionModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = true;

            ToDemoModeTimer.Start();
            ToInteractionModeTimer.Stop();

            SkeletonCheckTimer.Start();
            FastSkeletonCheckTimer.Stop();

            ChangeAppTimer.Stop();
        }

        private void OnToDemoModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;

            ToInteractionModeTimer.Start();
            ToDemoModeTimer.Stop();

            SkeletonCheckTimer.Stop();
            FastSkeletonCheckTimer.Start();

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
                //When the skeleton changes during the demo mode, the app which will be displayed shouldn't change anymore.
                if (WasSkeletonChanged())
                {
                    ChangeAppTimer.Stop();
                }
                else
                {
                    ToInteractionModeTimer.Reset();

                    FastSkeletonCheckTimer.Start();
                    SkeletonCheckTimer.Stop();

                    ChangeAppTimer.Start();
                }
            }
        }

        /// <summary>
        ///   Wether the skeleton was changed.
        /// </summary>
        /// <returns> </returns>
        internal bool WasSkeletonChanged()
        {
            return _lastSkeletonTime.Add(_demoModeConfig.SkeletonCheckTimeSpan) > DateTime.Now;
        }

        /// <summary>
        ///   The skeleton changed.
        /// </summary>
        internal void SkeletonChanged()
        {
            _lastSkeletonTime = DateTime.Now;
        }
    }
}