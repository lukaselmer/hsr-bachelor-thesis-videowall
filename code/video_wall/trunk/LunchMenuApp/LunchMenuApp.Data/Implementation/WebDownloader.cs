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

#region Usings

using System.Net;
using System.Text;
using LunchMenuApp.Data.Interfaces;

#endregion

namespace LunchMenuApp.Data.Implementation
{
    /// <summary>
    ///   The web downloader downloads a websites HTML.
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is can be made abstract, which is wrong.
    public class WebDownloader : IUrlDownloader
        // ReSharper restore ClassNeverInstantiated.Global
    {
        #region IUrlDownloader Members

        /// <summary>
        ///   Downloads the HTML.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> The HTML as string. </returns>
        public string Download(string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(url);
            }
        }

        #endregion
    }
}
