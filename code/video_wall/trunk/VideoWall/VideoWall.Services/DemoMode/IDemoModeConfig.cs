using System;
using System.Windows.Media;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode config interface
    /// </summary>
    public interface IDemoModeConfig
    {
        /// <summary>
        /// Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value>
        /// The background colors of the demo mode.
        /// </value>
        Color[] BackgroundColors { get; }

        TimeSpan SkeletonCheckTimeSpan { get; }
        TimeSpan ChangeAppTimeSpan { get; }
        TimeSpan CountdownTimeSpan { get; }
        TimeSpan FromActiveToDemoModeTimeSpan { get; }
        TimeSpan SkeletonTrackingTimeoutTimeSpan { get; }
    }
}