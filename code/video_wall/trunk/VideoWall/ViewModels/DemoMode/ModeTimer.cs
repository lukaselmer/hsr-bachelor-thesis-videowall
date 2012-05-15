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
using Common;

#endregion

namespace ViewModels.DemoMode
{
    public static class DispatcherTimerExtension
    {
        public static void Reset(this DispatcherTimer timer)
        {
            timer.Stop();
            timer.Start();
        }

        public static int GetIntervalSeconds(this DispatcherTimer timer)
        {
            return timer.Interval.Seconds;
        }
    }

    public class ModeTimer
    {
        private TimeSpan _demoModeTimeSpan;
        private TimeSpan _interactionModeTimeSpan;

        private bool _isInInteractionMode;
        private DateTime _lastSkeletonTime;
        private TimeSpan _skeletonCheckTimeSpan;


        public ModeTimer()
        {
            InitInteractionModeTimer();
            InitDemoModeTimer();
            InitSkeletonCheckTimer();

            IsInInteractionMode = true;
        }

        public DispatcherTimer DemoModeTimer { get; private set; }

        public DispatcherTimer InteractionModeTimer { get; private set; }

        public DispatcherTimer SkeletonCheckTimer { get; private set; }

        public bool IsInInteractionMode
        {
            get { return _isInInteractionMode; }
            private set
            {
                _isInInteractionMode = value;
            }
        }

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

        private void OnDemoModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = true;
            InteractionModeTimer.Start();
            DemoModeTimer.Stop();
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;
            DemoModeTimer.Start();
            InteractionModeTimer.Stop();
        }

        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (WasSkeletonChanged() && IsInInteractionMode)
            {
                InteractionModeTimer.Reset();
            }
            else if (!WasSkeletonChanged() && !IsInInteractionMode)
            {
                DemoModeTimer.Reset();
            }
        }

        public bool WasSkeletonChanged()
        {
            return _lastSkeletonTime.Add(_skeletonCheckTimeSpan) > DateTime.Now;
        }

        public void SkeletonChanged()
        {
            _lastSkeletonTime = DateTime.Now;
        }
    }
}