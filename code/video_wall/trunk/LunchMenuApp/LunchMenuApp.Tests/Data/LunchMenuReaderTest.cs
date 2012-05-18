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

using LunchMenuApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.Data
{
    ///<summary>
    ///  This is a test class for LunchMenuReaderTest and is intended to contain all LunchMenuReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class LunchMenuReaderTest
    {
        ///<summary>
        ///  A test for DownloadHtml
        ///</summary>
        [TestMethod]
        [DeploymentItem("LunchMenuApp.Data.dll")]
        public void DownloadHtmlTest()
        {
            var reader = new LunchMenuReader();
            var html = reader.Html;
            Assert.IsFalse(html.Length == 0);
            Assert.IsTrue(html.Contains("Menuplan"));
        }
    }
}