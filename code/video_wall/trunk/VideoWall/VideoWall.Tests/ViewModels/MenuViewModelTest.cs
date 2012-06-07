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
using VideoWall.Tests.ServiceModels.Apps;
using VideoWall.ViewModels.Menu;

#endregion

namespace VideoWall.Tests.ViewModels
{
    ///<summary>
    ///  This is a test class for MenuViewModelTest and is intended to contain all MenuViewModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class MenuViewModelTest
    {
        ///<summary>
        ///  A test for MenuViewModel Constructor.
        ///</summary>
        [TestMethod]
        public void MenuViewModelConstructorTest()
        {
            var extensionsFolder = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var player = new PlayerMock();
            var extensionsConfig = new ExtensionsConfig(extensionsFolder);
            var controller = new AppController(player, extensionsConfig);
            var vm = new MenuViewModel(controller);
            Assert.AreEqual(controller.Apps.Count(), vm.Apps.Count);
            Assert.IsNotNull(vm.CurrentApp);
            Assert.IsNotNull(vm.ChangeAppCommand);
            vm.ChangeAppCommand.Execute(vm.Apps[1]);
        }

        ///<summary>
        ///  Tests the change of the app.
        ///</summary>
        [TestMethod]
        public void ChangeAppTest()
        {
            var extensionsFolder = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var player = new PlayerMock();
            var extensionsConfig = new ExtensionsConfig(extensionsFolder);
            var controller = new AppController(player, extensionsConfig);
            var vm = new MenuViewModel(controller);
            Assert.IsNotNull(vm.ChangeAppCommand);
            vm.ChangeAppCommand.Execute(vm.Apps[1]);
            Assert.AreEqual(vm.Apps[1], vm.CurrentApp);
            vm.ChangeAppCommand.Execute(vm.Apps[0]);
            Assert.AreEqual(vm.Apps[0], vm.CurrentApp);
        }
    }
}
