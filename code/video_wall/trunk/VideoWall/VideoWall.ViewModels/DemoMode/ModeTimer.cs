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
using System.Windows.Threading;

#endregion

namespace VideoWall.ViewModels.DemoMode
{
    /// <summary>
    /// The mode timer
    /// </summary>
    public class ModeTimer
    {
        private TimeSpan _interactionModeTimeSpan; 
        private TimeSpan _demoModeTimeSpan;
        private TimeSpan _skeletonCheckTimeSpan;
        private TimeSpan _changeAppTimeSpan;

        private DateTime _lastSkeletonTime;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ModeTimer"/> class.
        /// </summary>
        public ModeTimer()
        {
            InitInteractionModeTimer();
            InitDemoModeTimer();
            InitSkeletonCheckTimer();
            InitChangeAppTimer();

            IsInInteractionMode = true;
        }

        #region Properties

        /// <summary>
        /// Gets the demo mode timer.
        /// </summary>
        public DispatcherTimer DemoModeTimer { get; private set; }

        /// <summary>
        /// Gets the interaction mode timer.
        /// </summary>
        public DispatcherTimer InteractionModeTimer { get; private set; }

        /// <summary>
        /// Gets the skeleton check timer.
        /// </summary>
        public DispatcherTimer SkeletonCheckTimer { get; private set; }

        /// <summary>
        /// Gets the change app timer.
        /// </summary>
        public DispatcherTimer ChangeAppTimer { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is in interaction mode.
        /// </summary>
        public bool IsInInteractionMode { get; private set; }

        #endregion

        private void InitDemoModeTimer()
        {
            _demoModeTimeSpan = TimeSpan.FromSeconds(5);
            DemoModeTimer = new DispatcherTimer { Interval = _demoModeTimeSpan };
            DemoModeTimer.Tick += OnDemoModeTimerTick;
        }

        private void InitInteractionModeTimer()
        {
            _interactionModeTimeSpan = TimeSpan.FromSeconds(10);
            InteractionModeTimer = new DispatcherTimer { Interval = _interactionModeTimeSpan };
            InteractionModeTimer.Tick += OnInteractionModeTimerTick;
            InteractionModeTimer.Start();
        }

        private void InitSkeletonCheckTimer()
        {
            _skeletonCheckTimeSpan = TimeSpan.FromSeconds(1);
            SkeletonCheckTimer = new DispatcherTimer { Interval = _skeletonCheckTimeSpan };
            SkeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            SkeletonCheckTimer.Start();
        }

        private void InitChangeAppTimer()
        {
            _changeAppTimeSpan = TimeSpan.FromSeconds(5);
            ChangeAppTimer = new DispatcherTimer { Interval = _changeAppTimeSpan };
            ChangeAppTimer.Tick += OnChangeAppTimerTick;
        }

        private void OnDemoModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = true;
            InteractionModeTimer.Start();
            DemoModeTimer.Stop();
            ChangeAppTimer.Stop();
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;
            DemoModeTimer.Start();
            ChangeAppTimer.Start();
            InteractionModeTimer.Stop();
        }

        /// <summary>
        /// Called when skeleton check timer tickes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (WasSkeletonChanged() && IsInInteractionMode)
            {
                InteractionModeTimer.Reset();
            }
            else if (!WasSkeletonChanged() && !IsInInteractionMode)
            {
                DemoModeTimer.Reset();
                ChangeAppTimer.Start();
            }
            else if (WasSkeletonChanged() && !IsInInteractionMode)
            {
                ChangeAppTimer.Stop();
            }
        }

        private void OnChangeAppTimerTick(object sender, EventArgs e)
        {
            ChangeAppTimer.Reset();
        }

        /// <summary>
        /// Wether the skeleton changed.
        /// </summary>
        /// <returns></returns>
        public bool WasSkeletonChanged()
        {
            return _lastSkeletonTime.Add(_skeletonCheckTimeSpan) > DateTime.Now;
        }

        /// <summary>
        /// Skeletons the changed.
        /// </summary>
        public void SkeletonChanged()
        {
            _lastSkeletonTime = DateTime.Now;
        }
    }
}