using System;
using System.Windows;
using System.Windows.Threading;

namespace DemoMode
{
    public class DemoModeTimer : Notifier
    {
        private readonly DispatcherTimer _timer;
        private readonly DispatcherTimer _secondTimer;
        private const int Interval = 5;
        private const int Second = 1;
        private bool _isInInteractionMode;
        private int _progress;

        public DemoModeTimer()
        {
            _timer = new DispatcherTimer() {Interval = new TimeSpan(0,0,Interval)};
            _timer.Tick += OnTimerTick;
            _timer.Start();
           _progress = Interval;
           _secondTimer = new DispatcherTimer() { Interval = new TimeSpan(0,0,Second) };
            _secondTimer.Tick += OnSecondTimerTick;
            _secondTimer.Start();
            IsInInteractionMode = true;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            IsInInteractionMode = false;
        }

        private void OnSecondTimerTick(object sender, EventArgs e)
        {
            Progress -= Second;
        }

        public bool IsInInteractionMode { get { return _isInInteractionMode; } private set { _isInInteractionMode = value;
            Notify("IsInInteractionMode");
            Notify("TimerStatus");
        }
        }

        public int Progress
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

        public void SkeletonWasChanged()
        {
            _timer.Stop();
            _timer.Start();
            _secondTimer.Stop();
            _secondTimer.Start();
            IsInInteractionMode = true;
            Progress = Interval;
        }
    }
}
