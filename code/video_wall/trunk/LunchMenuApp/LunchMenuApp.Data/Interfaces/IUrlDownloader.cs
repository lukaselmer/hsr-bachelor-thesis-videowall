namespace LunchMenuApp.Data.Interfaces
{
    /// <summary>
    /// The interface for the web downloader
    /// </summary>
    public interface IUrlDownloader
    {
        /// <summary>
        /// Downloads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        string Download(string url);
    }
}