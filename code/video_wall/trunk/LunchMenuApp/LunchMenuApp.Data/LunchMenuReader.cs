#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Net;
using System.Text;
using VideoWall.Common;

#endregion

namespace LunchMenuApp.Data
{
    /// <summary>
    ///   The LuchMenu reader.
    /// </summary>
    public class LunchMenuReader
    {
        //TODO: implement solution for websites with wrong or missing contents
        private const string UrlToMensaMenu = "http://hochschule-rapperswil.sv-group.ch/de.html";

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuReader" /> class.
        /// </summary>
        public LunchMenuReader()
        {
            DownloadHtml(UrlToMensaMenu);
        }

        /// <summary>
        ///   Gets the HTML of the current mensa menu.
        /// </summary>
        public string Html { get; private set; }

        private void DownloadHtml(string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                Html = null;
                try
                {
                    Html = client.DownloadString(url);
                }
                catch (WebException ex)
                {
                    Logger.Get.Error(ex.Message, ex);
                }
            }
        }
    }
}