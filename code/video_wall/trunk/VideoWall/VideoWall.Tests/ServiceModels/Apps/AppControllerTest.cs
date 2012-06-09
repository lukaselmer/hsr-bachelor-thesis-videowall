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
using VideoWall.ServiceModels.Apps.Implementation;
using VideoWall.Tests.Mocks;

#endregion

namespace VideoWall.Tests.ServiceModels.Apps
{
    ///<summary>
    ///  This is a test class for AppControllerTest and is intended to contain all AppControllerTest Unit Tests.
    ///</summary>
    [TestClass]
    public class AppControllerTest
    {
        ///<summary>
        ///  A test for AppController Constructor internals.
        ///</summary>
        [TestMethod]
        public void AppControllerConstructorTestInternals()
        {
            var extensionsFolder = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var player = new PlayerMock();
            var extensionsConfig = new ExtensionsConfig_Accessor(extensionsFolder);
            var controller = new AppController_Accessor(player, extensionsConfig, new ExtensionManager_Accessor());
            Assert.AreSame(player, controller._player);
        }

        ///<summary>
        ///  A test for AppController Constructor.
        ///</summary>
        [TestMethod]
        public void AppControllerConstructorTest()
        {
            var extensionsFolder = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var player = new PlayerMock();
            var extensionsConfig = new ExtensionsConfig(extensionsFolder);
            var controller = new AppController(player, extensionsConfig, new ExtensionManager());
            var apps = controller.Apps.ToList();
            Assert.AreEqual(2, apps.Count());
            Assert.IsNotNull(apps.First());
        }
    }
}
