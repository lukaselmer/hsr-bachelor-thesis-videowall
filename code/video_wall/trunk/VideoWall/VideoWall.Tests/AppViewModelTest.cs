using VideoWall.ViewModels.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoWall.Interfaces;

namespace VideoWall.Tests
{


    /// <summary>
    ///This is a test class for AppViewModelTest and is intended
    ///to contain all AppViewModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class AppViewModelTest
    {
        /// <summary>
        ///A test for AppViewModel Constructor
        ///</summary>
        [TestMethod]
        public void AppViewModelConstructorTest()
        {
            IApp app = null; // TODO: Initialize to an appropriate value
            AppViewModel target = new AppViewModel(app);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
