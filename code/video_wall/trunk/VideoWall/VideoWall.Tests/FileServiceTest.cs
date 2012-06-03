using System.IO;
using VideoWall.ServiceModels.Apps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.Interfaces;
using VideoWall.Tests.Mocks;

namespace VideoWall.Tests
{
    
    
    /// <summary>
    ///This is a test class for FileServiceTest and is intended
    ///to contain all FileServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileServiceTest
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
        ///A test for FileService Constructor
        ///</summary>
        [TestMethod()]
        public void FileServiceConstructorTest()
        {
            IApp app = new MockApp();
            var target = new FileService(app, new ExtensionsConfig("../../../Extensions"));
            Assert.AreEqual(new DirectoryInfo("../../../Extensions/Files/MockApp").FullName, target.ResourceDirectory);
        }
    }
}
