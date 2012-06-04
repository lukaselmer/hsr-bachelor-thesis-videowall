using System;
using System.Windows.Media;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode configuration
    /// </summary>
    public class DemoModeConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeConfig"/> class.
        /// </summary>
        /// <param name="backgroundColors">The background colors.</param>
        /// <param name="toDemoModeTimeSpan">To demo mode time span.</param>
        /// <param name="toInteractionModeTimeSpan">To interaction mode time span.</param>
        /// <param name="fastSkeletonTimeSpan">The fast skeleton time span.</param>
        /// <param name="skeletonCheckTimeSpan">The skeleton check time span.</param>
        /// <param name="changeAppTimeSpan">The change app time span.</param>
        // ReSharper disable MemberCanBeProtected.Global
        // Class is created by unity container, but ReSharper does not know that
        public DemoModeConfig(Color[] backgroundColors, TimeSpan toDemoModeTimeSpan, TimeSpan toInteractionModeTimeSpan,
            // ReSharper restore MemberCanBeProtected.Global
            TimeSpan fastSkeletonTimeSpan, TimeSpan skeletonCheckTimeSpan, TimeSpan changeAppTimeSpan)
        {
            BackgroundColors = backgroundColors;
            ToDemoModeTimeSpan = toDemoModeTimeSpan;
            ToInteractionModeTimeSpan = toInteractionModeTimeSpan;
            FastSkeletonTimeSpan = fastSkeletonTimeSpan;
            SkeletonCheckTimeSpan = skeletonCheckTimeSpan;
            ChangeAppTimeSpan = changeAppTimeSpan;
        }

        /// <summary>
        /// Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value>
        /// The background colors of the demo mode.
        /// </value>
        public Color[] BackgroundColors { get; private set; }

        /// <summary>
        /// Gets to demo mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan ToDemoModeTimeSpan { get; private set; }

        /// <summary>
        /// Gets to interaction mode time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan ToInteractionModeTimeSpan { get; private set; }

        /// <summary>
        /// Gets the fast skeleton time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan FastSkeletonTimeSpan { get; private set; }

        /// <summary>
        /// Gets the skeleton check time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan SkeletonCheckTimeSpan { get; private set; }

        /// <summary>
        /// Gets the change app time span.
        /// TODO: describe this property exactly
        /// </summary>
        public TimeSpan ChangeAppTimeSpan { get; private set; }
    }
}