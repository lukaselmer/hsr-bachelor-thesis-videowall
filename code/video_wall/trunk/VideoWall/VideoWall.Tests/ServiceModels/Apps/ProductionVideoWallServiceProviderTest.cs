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

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.Common.Exceptions;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Apps.Implementation;
using VideoWall.Tests.Mocks;

#endregion

namespace VideoWall.Tests.ServiceModels.Apps
{
    ///<summary>
    ///  This is a test class for ProductionVideoWallServiceProviderTest and is intended to contain all ProductionVideoWallServiceProviderTest Unit Tests.
    ///</summary>
    [TestClass]
    public class ProductionVideoWallServiceProviderTest
    {
        /// <summary>
        ///   Gets the extension test.
        /// </summary>
        [TestMethod]
        public void GetExtensionTest()
        {
            var extensionFolder = new ExtensionFolder(new DirectoryInfo(FileDirectoryForTests.TestFilePrefix + "Extensions/DiagnosticsApp"));
            var player = new PlayerMock();
            var provider = new ProductionVideoWallServiceProvider(extensionFolder, player);
            var fileService = provider.GetExtension<IFileService>();
            Assert.IsNotNull(fileService);
        }

        /// <summary>
        ///   Gets the extension test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (VideoWallException))]
        public void GetExtensionTestThrowing()
        {
            var extensionFolder = new ExtensionFolder(new DirectoryInfo(FileDirectoryForTests.TestFilePrefix + "Extensions/DiagnosticsApp2"));
            var player = new PlayerMock();
            var provider = new ProductionVideoWallServiceProvider(extensionFolder, player);
            provider.GetExtension<IFileService>();
        }
    }
}
