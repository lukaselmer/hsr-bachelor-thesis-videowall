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
using PosterApp.Data.Interfaces;
using PosterApp.ServiceModels.Implementation;
using PosterApp.ServiceModels.Interfaces;
using PosterApp.Tests.Mocks;

#endregion

namespace PosterApp.Tests.ServiceModels
{
    ///<summary>
    ///  This is a test class for PosterServiceTest and is intended to contain all PosterServiceTest Unit Tests
    ///</summary>
    [TestClass]
    public class PosterServiceTest
    {
        ///<summary>
        ///  A test for PosterService Constructor
        ///</summary>
        [TestMethod]
        public void PosterServiceConstructorTest()
        {
            IPosterReader posterReader = new PosterReaderMock();

            var service = new PosterService(posterReader);

            var posterReaderPosters = posterReader.Files.ToList();
            var sericePosters = service.Posters.ToList();

            Assert.AreEqual(posterReaderPosters.Count, sericePosters.Count);
            Assert.AreEqual(sericePosters[0].Image.PixelHeight, new Poster(posterReaderPosters[0]).Image.PixelHeight);
            Assert.AreEqual(sericePosters[0].Image.PixelWidth, new Poster(posterReaderPosters[0]).Image.PixelWidth);
        }
    }
}
