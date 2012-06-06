using System.Net;
using System.Text;
using LunchMenuApp.Data.Interfaces;

namespace LunchMenuApp.Data.Implementation
{
    /// <summary>
    /// The web downloader loads down a web sites HTML
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is can be made abstract, which is wrong.
    public class WebDownloader : IUrlDownloader
    // ReSharper restore ClassNeverInstantiated.Global
    {
        /// <summary>
        ///   Downloads the HTML.
        /// </summary>
        /// <param name="url"> The URL. </param>
        public string Download(string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(url);
            }
        }
    }
}
