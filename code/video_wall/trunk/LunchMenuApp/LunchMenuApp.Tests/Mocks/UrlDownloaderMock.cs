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
using LunchMenuApp.Data.Interfaces;

#endregion

namespace LunchMenuApp.Tests.Mocks
{
    internal class UrlDownloaderMock : IUrlDownloader
    {
        #region IUrlDownloader Members

        /// <summary>
        ///   Downloads the specified URL.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public string Download(string url)
        {
            throw new WebException();
        }

        #endregion
    }
}
