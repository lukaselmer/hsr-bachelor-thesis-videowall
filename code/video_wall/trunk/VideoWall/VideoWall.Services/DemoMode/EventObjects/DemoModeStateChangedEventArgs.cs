using System;

namespace VideoWall.ServiceModels.DemoMode.EventObjects
{
    /// <summary>
    /// The demo mode stat changed event args.
    /// </summary>
    public class DemoModeStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the state of the demo mode.
        /// </summary>
        /// <value>
        /// The state of the demo mode.
        /// </value>
        public VideoWallState VideoWallState { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeStateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="videoWallState">State of the demo mode.</param>
        public DemoModeStateChangedEventArgs(VideoWallState videoWallState)
        {
            VideoWallState = videoWallState;
        }
    }
}