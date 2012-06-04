namespace VideoWall.ServiceModels.DemoMode.Implementation
{
    /// <summary>
    /// The demo mode state represents the state of the demo mode
    /// </summary>
    public enum VideoWallState
    {
        /// <summary>
        /// When the application is active, the demo mode is hidden
        /// </summary>
        Active,
        /// <summary>
        /// When the application is inactive, the teaser text for the extensions is shown
        /// </summary>
        Teaser,
        /// <summary>
        /// When the application is inactive and a someone stands in front of the screen,
        /// the countdown starts ticking. After a certain time (e.g. after 5 seconds), the
        /// demo mode state is switched to inactive.
        /// </summary>
        Countdown
    }
}