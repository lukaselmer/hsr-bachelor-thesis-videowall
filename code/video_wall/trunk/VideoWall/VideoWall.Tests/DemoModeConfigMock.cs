using System;
using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode;

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
        public Color[] BackgroundColors { get { return new[] { Colors.Red, Colors.Blue }; } }

        /// <summary>
        /// Gets to demo mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan FromActiveToDemoModeTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets to interaction mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan ToInteractionModeTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the fast skeleton time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan FastSkeletonTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the skeleton check time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan SkeletonCheckTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the change app time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan ChangeAppTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the change app time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan CountdownTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }

        /// <summary>
        /// Gets the skeleton active time span.
        /// </summary>
        public TimeSpan SkeletonTrackingTimeoutTimeSpan { get { return TimeSpan.FromMilliseconds(100); } }
    }
}