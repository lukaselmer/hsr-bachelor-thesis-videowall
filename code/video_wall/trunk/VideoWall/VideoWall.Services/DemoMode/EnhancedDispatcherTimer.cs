using System;
using System.Windows.Threading;
using VideoWall.Common;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// An enhanced dispatcher timer which wraps the dispatcher timer.
    /// </summary>
    internal class EnhancedDispatcherTimer
    {
        /// <summary>
        /// The dispatcher timer
        /// </summary>
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedDispatcherTimer"/> class.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="toDemoModeTimeSpan">To demo mode time span.</param>
        /// <param name="started">if set to <c>true</c> [started].</param>
        public EnhancedDispatcherTimer(EventHandler eventHandler, TimeSpan toDemoModeTimeSpan, bool started = false)
        {
            PreOrPostCondition.AssertNotNull(eventHandler, "eventHandler");
            PreOrPostCondition.AssertNotNull(toDemoModeTimeSpan, "toDemoModeTimeSpan");

            _timer = new DispatcherTimer { Interval = toDemoModeTimeSpan };
            _timer.Tick += eventHandler;
            _timer.Tick += (sender, args) => Tick(sender, args);
            if (started) _timer.Start();
        }

        public event EventHandler<EventArgs> Tick = delegate { };

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            _timer.Stop();
            _timer.Start();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }

        public bool IsEnabled { get { return _timer.IsEnabled; } }

        public int IntervalSeconds { get { return _timer.Interval.Seconds; } }
    }
}