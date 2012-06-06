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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosterApp.Data.Implementation;
using PosterApp.Tests.Mocks;

#endregion

namespace PosterApp.Tests.Data
{
    ///<summary>
    ///  This is a test class for PosterReaderTest and is intended to contain all PosterReaderTest Unit Tests
    ///</summary>
    [TestClass]
    public class PosterReaderTest
    {
        ///<summary>
        ///  A test for PosterReader Constructor
        ///</summary>
        [TestMethod]
        public void PosterReaderConstructorTest()
        {
            var serviceProvider = new VideoWallServiceProviderMock();
            var reader = new PosterReader(serviceProvider);
            Assert.AreEqual(3, reader.Files.Count());
        }
    }
}
