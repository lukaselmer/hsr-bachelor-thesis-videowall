namespace VideoWall.ServiceModels.DemoMode
{
    /// <summary>
    /// Occures when the app should change.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="VideoWall.ServiceModels.DemoMode.DemoModeAppChangedEventArgs"/> instance containing the event data.</param>
    public delegate void DemoModeAppChangedEvent(object sender, DemoModeAppChangedEventArgs args);
}