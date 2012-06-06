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
using VideoWall.Common.Helpers;
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
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    public class LunchMenuReader : ILunchMenuReader
    // ReSharper restore ClassNeverInstantiated.Global
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
        public LunchMenuReader(IUrlDownloader urlDownloader)
        {
            PreOrPostCondition.AssertNotNull(urlDownloader, "urlDownloader");

            try
            {
                Html = urlDownloader.Download(UrlToMensaMenu);
            }
            catch (WebException ex)
            {
                Logger.Get.Error(ex.Message, ex);
                Html = null;
            }
        }

        #endregion
    }
}
