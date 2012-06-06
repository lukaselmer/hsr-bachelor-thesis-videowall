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

using System;
using System.Net.NetworkInformation;
using LunchMenuApp.Data.Implementation;
using LunchMenuApp.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.Data
{
    ///<summary>
    ///  This is a test class for LunchMenuReaderTest and is intended to contain all LunchMenuReaderTest Unit Tests.
    ///</summary>
    [TestClass]
    public class LunchMenuReaderTest
    {
        ///<summary>
        /// A test for LunchMenuReader Constructor This test is a little "stupid" because it only 
        /// works if the http server of the sa mensa is online. But: if the test does not work, the 
        /// menu cannot be downloaded and the app will not work. This is why this test makes sense. 
        /// If the computer is online, we assume that google.com can be reached.
        ///</summary>
        [TestMethod]
        public void LunchMenuReaderConstructorTest()
        {
            if (!Online()) Assert.Inconclusive("You do not seem to be online, therefore this test cannot be executed.");

            var lunchMenuReader = new LunchMenuReader(new WebDownloader());
            Assert.IsFalse(String.IsNullOrEmpty(lunchMenuReader.Html));
            Assert.IsTrue(lunchMenuReader.Html.Contains("<html"));
        }

        /// <summary>
        /// Lunches the menu reader constructor test throwing web exception.
        /// </summary>
        [TestMethod]
        public void LunchMenuReaderConstructorTestThrowingWebException()
        {
            var lunchMenuReader = new LunchMenuReader(new UrlDownloaderMock());
            Assert.IsNull(lunchMenuReader.Html);
        }

        private static bool Online()
        {
            var pingReply = new Ping().Send("google.com", 700);
            return pingReply != null && pingReply.Status == IPStatus.Success;
        }
    }
}
