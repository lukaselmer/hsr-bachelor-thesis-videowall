using System;
using System.Windows;
using System.Windows.Threading;

namespace DemoMode
{
    public static class DispatcherTimerExtension
    {
        public static void Reset(this DispatcherTimer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }

    public class ModeTimer : Notifier
    {
        private TimeSpan _interactionModeTimeSpan;
        private TimeSpan _demoModeTimeSpan;
        
        private DispatcherTimer _skeletonCheckTimer;
        private TimeSpan _skeletonCheckTimeSpan;

        private bool _isInInteractionMode;
        private TimeSpan _progress;
        private DateTime _lastSkeletonTime;


        public ModeTimer()
        {
            InitInteractionModeTimer();
            InitDemoModeTimer();
            InitSkeletonCheckTimer();

           _progress = _interactionModeTimeSpan;
            IsInInteractionMode = true;
        }

        public DispatcherTimer DemoModeTimer { get; private set; }

        public DispatcherTimer InteractionModeTimer { get; set; }

        private void InitDemoModeTimer()
        {
            _demoModeTimeSpan = new TimeSpan(0, 0, 5);
            DemoModeTimer = new DispatcherTimer() { Interval = _demoModeTimeSpan };
            DemoModeTimer.Tick += OnDemoModeTimerTick;
        }

        private void InitInteractionModeTimer()
        {
            _interactionModeTimeSpan = new TimeSpan(0, 0, 5);
            InteractionModeTimer = new DispatcherTimer() { Interval = _interactionModeTimeSpan };
            InteractionModeTimer.Tick += OnInteractionModeTimerTick;
            InteractionModeTimer.Start();
        }

        private void InitSkeletonCheckTimer()
        {
            _skeletonCheckTimeSpan = new TimeSpan(0, 0, 1);
            _skeletonCheckTimer = new DispatcherTimer() { Interval = _skeletonCheckTimeSpan};
            _skeletonCheckTimer.Tick += OnSkeletonCheckTimerTick;
            _skeletonCheckTimer.Start();
        }

        private void OnDemoModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = true;
            Progress = _interactionModeTimeSpan;
            InteractionModeTimer.Start();
            DemoModeTimer.Stop();
        }

        private void OnInteractionModeTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;
            Progress = _demoModeTimeSpan;
            DemoModeTimer.Start();
            InteractionModeTimer.Stop();
        }

        private void OnSkeletonCheckTimerTick(object sender, EventArgs e)
        {
            if (WasSkeletonChanged() && IsInInteractionMode)
            {
                InteractionModeTimer.Reset();
                Progress = _interactionModeTimeSpan;
            }
            else if (!WasSkeletonChanged() && !IsInInteractionMode)
            {
                DemoModeTimer.Reset();
                Progress = _demoModeTimeSpan;
            }
            else
            {
                Progress -= _skeletonCheckTimeSpan;   
            }
        }

        private bool WasSkeletonChanged()
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
                Notify("TimerStatus");
            }
        }

        public TimeSpan Progress
        {
            get { return _progress; } private set
            {
                _progress = value;
                Notify("Progress");
            }
        }

        public string TimerStatus
        {
            get { return IsInInteractionMode ? "Interaktionsmodus" : "Demomodus"; }
        }

        public void SkeletonChanged()
        {
                _lastSkeletonTime = DateTime.Now;               
        }
    }
}
