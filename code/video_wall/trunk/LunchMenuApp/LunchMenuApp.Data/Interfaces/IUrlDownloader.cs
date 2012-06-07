#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

namespace LunchMenuApp.Data.Interfaces
{
    /// <summary>
    ///   The interface for the web downloader
    /// </summary>
    public interface IUrlDownloader
    {
        /// <summary>
        ///   Downloads the specified URL.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> The HTML as string. </returns>
        string Download(string url);
    }
}
