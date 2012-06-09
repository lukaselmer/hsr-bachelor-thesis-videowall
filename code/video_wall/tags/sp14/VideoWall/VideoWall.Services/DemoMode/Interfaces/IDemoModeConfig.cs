using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace VideoWall.ServiceModels.DemoMode.Interfaces
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
        IEnumerable<Color> BackgroundColors { get; }

        /// <summary>
        /// Gets the skeleton check time span.
        /// The skeleton check time span is the frequency of which the state is checked.
        /// 10-50 milliseconds is a good value.
        /// </summary>
        TimeSpan SkeletonCheckTimeSpan { get; }

        /// <summary>
        /// Gets the change app time span.
        /// This time span defines after how much time in the demo mode the current app is changed automatically.
        /// 20-40 seconds is a good value.
        /// </summary>
        TimeSpan ChangeAppTimeSpan { get; }

        /// <summary>
        /// Gets the countdown time span.
        /// The countdown time span defines how long the countdown time to "enter" the app is.
        /// Use a value just a little smaller than an even number: 4.999 seconds is a good value.
        /// </summary>
        TimeSpan CountdownTimeSpan { get; }

        /// <summary>
        /// Gets from active to demo mode time span.
        /// If noboady interacts with the video wall, this defines how long it will take until the app
        /// switches from the active state to the teaser (demo mode) state.
        /// 10 seconds is a good value.
        /// </summary>
        TimeSpan FromActiveToDemoModeTimeSpan { get; }

        /// <summary>
        /// Gets the skeleton tracking timeout time span.
        /// This time span defines the timeout between how long ago the last skeleton has changed and the skeleton 
        /// is not tracked anymore.
        /// 500 milliseconds is a good value.
        /// </summary>
        TimeSpan SkeletonTrackingTimeoutTimeSpan { get; }
    }
}