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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosterApp.ServiceModels.Implementation;
using PosterApp.Tests.Mocks;

#endregion

namespace PosterApp.Tests.ServiceModels
{
    ///<summary>
    ///  This is a test class for PosterTest and is intended to contain all PosterTest Unit Tests
    ///</summary>
    [TestClass]
    public class PosterTest
    {
        ///<summary>
        ///  A test for Poster Constructor
        ///</summary>
        [TestMethod]
        public void PosterConstructorTest()
        {
            var poster = new Poster(new FileServiceMock().TestFilePath);
            Assert.IsNotNull(poster.Image);
            Assert.AreEqual(742, poster.Image.PixelHeight);
            Assert.AreEqual(1044, poster.Image.PixelWidth);
        }
    }
}
