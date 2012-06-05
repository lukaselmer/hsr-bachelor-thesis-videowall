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
using VideoWall.Common.Logging;

#endregion

namespace LunchMenuApp.Data.Implementation
{
    /// <summary>
    ///   The luch menu reader.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class LunchMenuReader : ILunchMenuReader
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        private const string UrlToMensaMenu = "http://hochschule-rapperswil.sv-group.ch/de.html";

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the HTML of the current mensa menu.
        /// </summary>
        public string Html { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuReader" /> class.
        /// </summary>
        public LunchMenuReader()
        {
            DownloadHtml(UrlToMensaMenu);
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Downloads the HTML.
        /// </summary>
        /// <param name="url"> The URL. </param>
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

        #endregion
    }
}
