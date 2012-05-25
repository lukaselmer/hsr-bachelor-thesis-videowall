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
        ///A test for Apps
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void AppsTest()
        {
            //TODO Delia
//            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
//            MenuViewModel_Accessor target = new MenuViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
//            List<AppViewModel> expected = null; // TODO: Initialize to an appropriate value
//            List<AppViewModel> actual;
//            target.Apps = expected;
//            actual = target.Apps;
//            Assert.AreEqual(expected, actual);
//            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ChangeAppCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void ChangeAppCommandTest()
        {
//            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
//            MenuViewModel_Accessor target = new MenuViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
//            ICommand expected = null; // TODO: Initialize to an appropriate value
//            ICommand actual;
//            target.ChangeAppCommand = expected;
//            actual = target.ChangeAppCommand;
//            Assert.AreEqual(expected, actual);
//            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CurrentApp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void CurrentAppTest()
        {
//            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
//            MenuViewModel_Accessor target = new MenuViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
//            AppViewModel expected = null; // TODO: Initialize to an appropriate value
//            AppViewModel actual;
//            target.CurrentApp = expected;
//            actual = target.CurrentApp;
//            Assert.AreEqual(expected, actual);
//            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
