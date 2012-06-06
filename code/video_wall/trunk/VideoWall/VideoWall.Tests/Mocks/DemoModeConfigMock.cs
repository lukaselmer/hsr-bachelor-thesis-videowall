using System;
using System.Collections.Generic;
using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode.Interfaces;

namespace VideoWall.Tests
{
    /// <summary>
    /// The demo mode config mock for the tests
    /// </summary>
    class DemoModeConfigMock : IDemoModeConfig
    {
        /// <summary>
        /// Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value>
        /// The background colors of the demo mode.
        /// </value>
        public IEnumerable<Color> BackgroundColors { get { return new[] { Colors.Red, Colors.Blue }; } }

        /// <summary>
        /// Gets from active to demo mode time span.
        /// If noboady interacts with the video wall, this defines how long it will take until the app
        /// switches from the active state to the teaser (demo mode) state.
        /// </summary>
        public TimeSpan FromActiveToDemoModeTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the skeleton check time span.
        /// The skeleton check time span is the frequency of which the state is checked.
        /// 10-50 milliseconds is a good value.
        /// </summary>
        public TimeSpan SkeletonCheckTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the change app time span.
        /// This time span defines after how much time in the demo mode the current app is changed automatically.
        /// 20-40 seconds is a good value.
        /// </summary>
        public TimeSpan ChangeAppTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the countdown time span.
        /// The countdown time span defines how long the countdown time to "enter" the app is.
        /// Use a value just a little smaller than an even number: 4.999 seconds is a good value.
        /// </summary>
        public TimeSpan CountdownTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the skeleton tracking timeout time span.
        /// This time span defines the timeout between how long ago the last skeleton has changed and the skeleton
        /// is not tracked anymore.
        /// </summary>
        public TimeSpan SkeletonTrackingTimeoutTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }
    }
}