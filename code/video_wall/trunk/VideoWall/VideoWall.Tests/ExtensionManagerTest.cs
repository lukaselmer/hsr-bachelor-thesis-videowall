using System.IO;
using VideoWall.ServiceModels.Apps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoWall.Interfaces;
using VideoWall.Tests.Mocks;

namespace VideoWall.Tests
{
    
    
    /// <summary>
    ///This is a test class for ExtensionManagerTest and is intended
    ///to contain all ExtensionManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtensionManagerTest
    {

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        
        /// <summary>
        ///A test for InitApp
        ///</summary>
        [TestMethod()]
        public void InitAppTest()
        {
            IApp app = new MockApp();
            const string expected = "../../../Extensions/Files/MockApp";
            var actual = ExtensionManager.InitApp(app);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateDirectoryWith
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ServiceModels.dll")]
        public void CreateDirectoryWithTest()
        {
            var path = ExtensionManager_Accessor.FolderNameOfExtensions;
            ExtensionManager_Accessor.CreateDirectoryWith(path);
            Assert.IsTrue(Directory.Exists(path));
        }
    }
}
