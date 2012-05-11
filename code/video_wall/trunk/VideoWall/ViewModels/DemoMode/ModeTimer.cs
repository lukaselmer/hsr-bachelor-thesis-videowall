using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using Common;

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

        public class ModeTimer : Notifier
        {
            private TimeSpan _interactionModeTimeSpan;
            private TimeSpan _demoModeTimeSpan;
            private TimeSpan _skeletonCheckTimeSpan;

            private bool _isInInteractionMode;
            private DateTime _lastSkeletonTime;


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
            private void InitDemoModeTimer()
            {
                _demoModeTimeSpan = new TimeSpan(0, 0, 5);
                DemoModeTimer = new DispatcherTimer() { Interval = _demoModeTimeSpan };
                DemoModeTimer.Tick += OnDemoModeTimerTick;
            }

            private void InitInteractionModeTimer()
            {
                _interactionModeTimeSpan = new TimeSpan(0, 0, 10);
                InteractionModeTimer = new DispatcherTimer() { Interval = _interactionModeTimeSpan };
                InteractionModeTimer.Tick += OnInteractionModeTimerTick;
                InteractionModeTimer.Start();
            }

            private void InitSkeletonCheckTimer()
            {
                _skeletonCheckTimeSpan = new TimeSpan(0, 0, 1);
                SkeletonCheckTimer = new DispatcherTimer() { Interval = _skeletonCheckTimeSpan };
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

            public bool IsInInteractionMode
            {
                get { return _isInInteractionMode; }
                private set
                {
                    _isInInteractionMode = value;
                    Notify("IsInInteractionMode");
                }
            }

            public void SkeletonChanged()
            {
                _lastSkeletonTime = DateTime.Now;
            }
        }
}
