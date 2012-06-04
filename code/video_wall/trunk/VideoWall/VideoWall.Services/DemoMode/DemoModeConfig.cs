using System;
using System.Windows.Media;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode configuration
    /// </summary>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class DemoModeConfig : IDemoModeConfig
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeConfig"/> class.
        /// </summary>
        /// <param name="backgroundColors">The background colors.</param>
        /// <param name="skeletonCheckTimeSpan">The skeleton check time span.</param>
        /// <param name="changeAppTimeSpan">The change app time span.</param>
        /// <param name="fromActiveToDemoModeTimeSpan">From active to demo mode time span.</param>
        /// <param name="countdownTimeSpan">The countdown time span.</param>
        /// <param name="skeletonTrackingTimeoutTimeSpan">The skeleton active time span.</param>
        public DemoModeConfig(Color[] backgroundColors, TimeSpan skeletonCheckTimeSpan, TimeSpan changeAppTimeSpan,
            TimeSpan fromActiveToDemoModeTimeSpan, TimeSpan countdownTimeSpan, TimeSpan skeletonTrackingTimeoutTimeSpan)
        {
            BackgroundColors = backgroundColors;

            SkeletonCheckTimeSpan = skeletonCheckTimeSpan;
            ChangeAppTimeSpan = changeAppTimeSpan;
            FromActiveToDemoModeTimeSpan = fromActiveToDemoModeTimeSpan;
            CountdownTimeSpan = countdownTimeSpan;
            SkeletonTrackingTimeoutTimeSpan = skeletonTrackingTimeoutTimeSpan;
        }

        /// <summary>
        /// Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value>
        /// The background colors of the demo mode.
        /// </value>
        public Color[] BackgroundColors { get; private set; }

        public TimeSpan SkeletonCheckTimeSpan { get; private set; }
        public TimeSpan ChangeAppTimeSpan { get; private set; }
        public TimeSpan CountdownTimeSpan { get; private set; }
        public TimeSpan FromActiveToDemoModeTimeSpan { get; private set; }
        public TimeSpan SkeletonTrackingTimeoutTimeSpan { get; private set; }
    }
}