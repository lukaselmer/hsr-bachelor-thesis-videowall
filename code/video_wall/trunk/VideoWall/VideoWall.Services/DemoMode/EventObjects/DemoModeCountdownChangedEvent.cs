namespace VideoWall.ServiceModels.DemoMode.EventObjects
{
    /// <summary>
    /// Occurs when the demo mode countdown changed
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="DemoModeCountdownChangedEventArgs"/> instance containing the event data.</param>
    public delegate void DemoModeCountdownChangedEvent(object sender, DemoModeCountdownChangedEventArgs args);
}