using VideoWall.Tests.Mocks;
using VideoWall.ViewModels.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoWall.ServiceModels.Apps;
using System.Collections.Generic;
using System.Windows.Input;

namespace VideoWall.Tests
{
    
    
    /// <summary>
    ///This is a test class for MenuViewModelTest and is intended
    ///to contain all MenuViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuViewModelTest
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
        ///A test for MenuViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void MenuViewModelConstructorTest()
        {
            var appController = new AppController();
            
            var target = new MenuViewModel(appController);
            Assert.IsNotNull(target.CurrentApp);
        }

        /// <summary>
        ///A test for OnChangeApp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnChangeAppTest()
        {
            var app = new MockApp();
            var appObject = new AppViewModel(app);
            var appController = new AppController();
            var target = new MenuViewModel_Accessor(appController);
            target.OnChangeApp(appObject);
            Assert.AreSame(appObject,target.CurrentApp);
        }
    }
}
