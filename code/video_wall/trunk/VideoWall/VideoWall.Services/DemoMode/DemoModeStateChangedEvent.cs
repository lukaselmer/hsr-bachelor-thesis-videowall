namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// The demo mode state changed event occures when the demo mode state has changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="VideoWall.ServiceModels.DemoMode.DemoModeStateChangedEventArgs"/> instance containing the event data.</param>
    public delegate void DemoModeStateChangedEvent(object sender, DemoModeStateChangedEventArgs args);
}