namespace VideoWall.ServiceModels.DemoMode.EventObjects
{
    /// <summary>
    /// Occurs when the color of the demo mode changes.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="DemoModeColorChangedEventArgs"/> instance containing the event data.</param>
    public delegate void DemoModeColorChangedEvent(object sender, DemoModeColorChangedEventArgs args);
}