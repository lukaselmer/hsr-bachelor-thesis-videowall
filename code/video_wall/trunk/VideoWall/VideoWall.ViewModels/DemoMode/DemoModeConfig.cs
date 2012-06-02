using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using VideoWall.Common.Extensions;

namespace VideoWall.ViewModels.DemoMode
{
    /// <summary>
    /// The demo mode configuration
    /// </summary>
    public class DemoModeConfig
    {
        private readonly Color[] _backgroundColors;
        private readonly TimeSpan _toDemoModeTimeSpan;
        private readonly TimeSpan _toInteractionModeTimeSpan;
        private readonly TimeSpan _fastSkeletonTimeSpan;
        private readonly TimeSpan _skeletonCheckTimeSpan;
        private readonly TimeSpan _changeAppTimeSpan;

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeConfig"/> class.
        /// </summary>
        /// <param name="backgroundColors">The background colors.</param>
        /// <param name="toDemoModeTimeSpan">To demo mode time span.</param>
        /// <param name="toInteractionModeTimeSpan">To interaction mode time span.</param>
        /// <param name="fastSkeletonTimeSpan">The fast skeleton time span.</param>
        /// <param name="skeletonCheckTimeSpan">The skeleton check time span.</param>
        /// <param name="changeAppTimeSpan">The change app time span.</param>
        public DemoModeConfig(Color[] backgroundColors, TimeSpan toDemoModeTimeSpan, TimeSpan toInteractionModeTimeSpan,
            TimeSpan fastSkeletonTimeSpan, TimeSpan skeletonCheckTimeSpan, TimeSpan changeAppTimeSpan)
        {
            _backgroundColors = backgroundColors;
            _toDemoModeTimeSpan = toDemoModeTimeSpan;
            _toInteractionModeTimeSpan = toInteractionModeTimeSpan;
            _fastSkeletonTimeSpan = fastSkeletonTimeSpan;
            _skeletonCheckTimeSpan = skeletonCheckTimeSpan;
            _changeAppTimeSpan = changeAppTimeSpan;
        }

        /// <summary>
        /// Gets or sets the background colors of the demo mode.
        /// </summary>
        /// <value>
        /// The background colors of the demo mode.
        /// </value>
        public IEnumerable<Color> BackgroundColors { get { return _backgroundColors; } }

        public TimeSpan ToDemoModeTimeSpan
        {
            get
            {
                return _toDemoModeTimeSpan;
            }
        }

        public TimeSpan ToInteractionModeTimeSpan
        {
            get
            {
                return _toInteractionModeTimeSpan;
            }
        }
        public TimeSpan FastSkeletonTimeSpan
        {
            get
            {
                return _fastSkeletonTimeSpan;
            }
        }
        public TimeSpan SkeletonCheckTimeSpan
        {
            get
            {
                return _skeletonCheckTimeSpan;
            }
        }
        public TimeSpan ChangeAppTimeSpan
        {
            get
            {
                return _changeAppTimeSpan;
            }
        }
    }
}