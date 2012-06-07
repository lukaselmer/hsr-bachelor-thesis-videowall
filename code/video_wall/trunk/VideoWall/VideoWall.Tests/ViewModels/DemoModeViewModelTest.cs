using System;
using System.Windows;
using System.Windows.Media;
using VideoWall.ServiceModels.Apps.Implementation;
using VideoWall.ServiceModels.DemoMode.Implementation;
using VideoWall.Tests.Mocks;
using VideoWall.Tests.ServiceModels.Apps;
using VideoWall.ViewModels.DemoMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.ViewModels.Skeletons;
using VideoWall.ViewModels.Menu;
using VideoWall.ServiceModels.DemoMode.Interfaces;

namespace VideoWall.Tests.ViewModels
{
    /// <summary>
    ///This is a test class for DemoModeViewModelTest and is intended
    ///to contain all DemoModeViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DemoModeViewModelTest
    {
        /// <summary>
        ///A test for DemoModeViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void DemoModeViewModelConstructorTest()
        {
            var player = new PlayerMock();

            var extensionsFolder = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var extensionsConfig = new ExtensionsConfig(extensionsFolder);
            var controller = new AppController(player, extensionsConfig);

            var playerViewModel = new PlayerViewModel(new PlayerMock());
            var menuViewModel = new MenuViewModel(controller);

            var t = TimeSpan.FromDays(1);
            var demoModeConfig = new DemoModeConfig(new[] { Colors.Red, Colors.Blue }, t, t, t, t, t);
            var demoModeService = new DemoModeService(player, demoModeConfig);

            var vm = new DemoModeViewModel(playerViewModel, menuViewModel, demoModeService);
            Assert.AreEqual(Visibility.Collapsed, vm.CountDownVisibility);
            Assert.AreEqual(Visibility.Collapsed, vm.DemoModeVisibility);
            Assert.AreEqual(Visibility.Collapsed, vm.TeaserVisibility);
            
            Assert.AreSame(playerViewModel, vm.PlayerViewModel);
        }
    }
}
