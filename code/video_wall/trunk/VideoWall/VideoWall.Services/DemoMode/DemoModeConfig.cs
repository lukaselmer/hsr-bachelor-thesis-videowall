#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.Windows.Media;

#endregion

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    ///   The demo mode configuration
    /// </summary>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class DemoModeConfig : IDemoModeConfig
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="DemoModeConfig" /> class.
        /// </summary>
        /// <param name="backgroundColors"> The background colors. </param>
        /// <param name="skeletonCheckTimeSpan"> The skeleton check time span. </param>
        /// <param name="changeAppTimeSpan"> The change app time span. </param>
        /// <param name="fromActiveToDemoModeTimeSpan"> From active to demo mode time span. </param>
        /// <param name="countdownTimeSpan"> The countdown time span. </param>
        /// <param name="skeletonTrackingTimeoutTimeSpan"> The skeleton active time span. </param>
        // ReSharper disable ParameterTypeCanBeEnumerable.Local
        // Color[] cannot be changed to IEnumerable<Color> because the unity container uses <array/> which is not compatible with IEnumerable<Color>
        public DemoModeConfig(Color[] backgroundColors, TimeSpan skeletonCheckTimeSpan, TimeSpan changeAppTimeSpan,
                              TimeSpan fromActiveToDemoModeTimeSpan, TimeSpan countdownTimeSpan, TimeSpan skeletonTrackingTimeoutTimeSpan)
        // ReSharper restore ParameterTypeCanBeEnumerable.Local
        {
            BackgroundColors = backgroundColors;

            SkeletonCheckTimeSpan = skeletonCheckTimeSpan;
            ChangeAppTimeSpan = changeAppTimeSpan;
            FromActiveToDemoModeTimeSpan = fromActiveToDemoModeTimeSpan;
            CountdownTimeSpan = countdownTimeSpan;
            SkeletonTrackingTimeoutTimeSpan = skeletonTrackingTimeoutTimeSpan;
        }

        /// <summary>
        ///   Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value> The background colors of the demo mode. </value>
        public IEnumerable<Color> BackgroundColors { get; private set; }

        /// <summary>
        /// Gets the skeleton check time span.
        /// The skeleton check time span is the frequency of which the state is checked.
        /// 10-50 milliseconds is a good value.
        /// </summary>
        public TimeSpan SkeletonCheckTimeSpan { get; private set; }

        /// <summary>
        /// Gets the change app time span.
        /// This time span defines after how much time in the demo mode the current app is changed automatically.
        /// 20-40 seconds is a good value.
        /// </summary>
        public TimeSpan ChangeAppTimeSpan { get; private set; }

        /// <summary>
        /// Gets from active to demo mode time span.
        /// If noboady interacts with the video wall, this defines how long it will take until the app
        /// switches from the active state to the teaser (demo mode) state.
        /// 10 seconds is a good value.
        /// </summary>
        public TimeSpan FromActiveToDemoModeTimeSpan { get; private set; }

        /// <summary>
        /// Gets the countdown time span.
        /// The countdown time span defines how long the countdown time to "enter" the app is.
        /// Use a value just a little smaller than an even number: 4.999 seconds is a good value.
        /// </summary>
        public TimeSpan CountdownTimeSpan { get; private set; }

        /// <summary>
        /// Gets the skeleton tracking timeout time span.
        /// This time span defines the timeout between how long ago the last skeleton has changed and the skeleton
        /// is not tracked anymore.
        /// 500 milliseconds is a good value.
        /// </summary>
        public TimeSpan SkeletonTrackingTimeoutTimeSpan { get; private set; }

    }
}
