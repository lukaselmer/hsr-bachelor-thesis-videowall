namespace LunchMenuApp.Data.Interfaces
{
    /// <summary>
    /// The luch menu reader interfaces.
    /// </summary>
    public interface ILunchMenuReader
    {
        /// <summary>
        ///   Gets the HTML of the current mensa menu.
        /// </summary>
        string Html { get; }
    }
}