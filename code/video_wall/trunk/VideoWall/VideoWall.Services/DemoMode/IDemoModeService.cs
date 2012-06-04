using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode.EventObjects;

namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode service provides the service for the demo mode.
    /// </summary>
    public interface IDemoModeService
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        VideoWallState State { get; }

        /// <summary>
        /// Gets or sets the color of the current.
        /// </summary>
        /// <value>
        /// The color of the current.
        /// </value>
        Color CurrentColor { get; }

        /// <summary>
        /// Gets the countdown.
        /// </summary>
        int Countdown { get; }

        /// <summary>
        /// Occurs when demo mode state changed.
        /// </summary>
        event DemoModeStateChangedEvent DemoModeStateChanged;

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        event DemoModeAppChangedEvent DemoModeAppChanged;

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        event DemoModeColorChangedEvent DemoModeColorChanged;

        /// <summary>
        /// Occurs when demo mode countdown changed.
        /// </summary>
        event DemoModeCountdownChangedEvent DemoModeCountdownChanged;
    }
}