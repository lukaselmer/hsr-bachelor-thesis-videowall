using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoWall.ServiceModels.Player.Interfaces;
using VideoWall.ServiceModels.DemoMode.Interfaces;
using VideoWall.Tests.Mocks;

namespace VideoWall.Tests
{
    /// <summary>
    ///This is a test class for DemoModeServiceTest and is intended
    ///to contain all DemoModeServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DemoModeServiceTest
    {
        /// <summary>
        ///A test for DemoModeService Constructor
        ///</summary>
        [TestMethod()]
        public void DemoModeServiceConstructorTest()
        {
            var t = TimeSpan.FromDays(1);
            var player = new PlayerMock();
            var demoModeConfig = new DemoModeConfig(new[] { Colors.Red, Colors.Blue }, t, t, t, t, t);
            var service = new DemoModeService(player, demoModeConfig);
            Assert.IsNotNull(service.CurrentBackgroundColor);
            Assert.AreEqual(VideoWallState.Active, service.State);
        }
    }
}
