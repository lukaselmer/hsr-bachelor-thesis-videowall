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

        /// <summary>
        /// Gets to demo mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        TimeSpan ToDemoModeTimeSpan { get; }

        /// <summary>
        /// Gets to interaction mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        TimeSpan ToInteractionModeTimeSpan { get; }

        /// <summary>
        /// Gets the fast skeleton time span.
        /// TODO: describe this property exactly
        /// </summary>
        TimeSpan FastSkeletonTimeSpan { get; }

        /// <summary>
        /// Gets the skeleton check time span.
        /// TODO: describe this property exactly
        /// </summary>
        TimeSpan SkeletonCheckTimeSpan { get; }

        /// <summary>
        /// Gets the change app time span.
        /// TODO: describe this property exactly
        /// </summary>
        TimeSpan ChangeAppTimeSpan { get; }
    }
}