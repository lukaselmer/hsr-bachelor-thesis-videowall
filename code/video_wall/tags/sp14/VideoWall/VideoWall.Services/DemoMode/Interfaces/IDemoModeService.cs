using System;
using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode.Implementation;

namespace VideoWall.ServiceModels.DemoMode.Interfaces
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
        Color CurrentBackgroundColor { get; }

        /// <summary>
        /// Gets the countdown.
        /// </summary>
        int Countdown { get; }

        /// <summary>
        /// Occurs when demo mode state changed.
        /// </summary>
        event EventHandler DemoModeStateChanged;

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        event EventHandler DemoModeAppChanged;

        /// <summary>
        /// Occurs when demo mode app should be changed.
        /// </summary>
        event EventHandler DemoModeColorChanged;

        /// <summary>
        /// Occurs when demo mode countdown changed.
        /// </summary>
        event EventHandler DemoModeCountdownChanged;
    }
}