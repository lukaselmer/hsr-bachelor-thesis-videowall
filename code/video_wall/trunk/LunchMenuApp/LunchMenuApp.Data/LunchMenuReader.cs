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

using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using Common;
using HtmlAgilityPack;

#endregion

namespace Data
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuReader
    {
        private const string UrlToMensaMenu = "http://hochschule-rapperswil.sv-group.ch/de.html";

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuReader" /> class.
        /// </summary>
        public LunchMenuReader()
        {
            DownloadHtml(UrlToMensaMenu);
        }

        private void DownloadHtml(string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                Html = client.DownloadString(url);
            }
        }

        /// <summary>
        /// Gets the HTML of the current mensa menu.
        /// </summary>
        public string Html { get; private set; }
    }
}