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
using VideoWall.ServiceModels.Apps.Implementation;

#endregion

namespace VideoWall.Tests.ServiceModels.Apps
{
    ///<summary>
    ///  This is a test class for FileServiceTest and is intended to contain all FileServiceTest Unit Tests.
    ///</summary>
    [TestClass]
    public class FileServiceTest
    {
        private static TestContext _testContext;

        /// <summary>
        /// Initializes the TestClass.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
        }

        ///<summary>
        ///  A test for FileService Constructor.
        ///</summary>
        [TestMethod]
        public void FileServiceConstructorTest()
        {
            var x = _testContext.DeploymentDirectory;

            var extensionFolder = new ExtensionFolder(new DirectoryInfo(FileDirectoryForTests.TestFilePrefix + "ExtensionWithFileService"));
            var service = new FileService(extensionFolder);
            Assert.AreEqual(new DirectoryInfo(FileDirectoryForTests.TestFilePrefix + "ExtensionWithFileService/Files").FullName, service.ResourceDirectory);
        }

        ///<summary>
        ///  A test for FileService Constructor with exception.
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(VideoWallException))]
        public void FileServiceConstructorTestWithException()
        {
            var extensionFolder = new ExtensionFolder(new DirectoryInfo(FileDirectoryForTests.TestFilePrefix + "ExtensionWithoutFileService"));
            new FileService(extensionFolder);
        }
    }
}
