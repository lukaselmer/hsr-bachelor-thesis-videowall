using System;
using System.Threading;
using System.Windows;
using Common;

namespace DemoMode
{
    public class DemoModeViewModel : Notifier
    {
        private readonly Timer _timer;
        private readonly Timer _secondTimer;
        private const double Interval = 5000;
        private const double Second = 1000;
        private bool _isInInteractionMode;
        private double _progress;

        public DemoModeViewModel()
        {
            _timer = new Timer()
            //_timer = new Timer(Interval) { AutoReset = true, Enabled = true};
            //_progress = Interval / Second;
            //_secondTimer = new Timer(Second) { AutoReset = true, Enabled = true };
            //_secondTimer.Elapsed += SecondTimerElapsed;
            //_timer.Elapsed += OnTimerElapsed;
            //IsInInteractionMode = true;
        }

        //private void SecondTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    Progress -= 1;
        //}

        public bool IsInInteractionMode { get { return _isInInteractionMode; } private set { _isInInteractionMode = value;
            Notify("IsInInteractionMode");
            Notify("TimerStatus");
        }
        }



        //private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    IsInInteractionMode = false;
        //}

        public double Progress
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
            Progress = Interval / 1000;
        }
    }
}
