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

using System;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.ServiceModels.DemoMode.Implementation;
using VideoWall.Tests.Mocks;

#endregion

namespace VideoWall.Tests.ServiceModels.DemoMode
{
    ///<summary>
    ///  This is a test class for DemoModeServiceTest and is intended to contain all DemoModeServiceTest Unit Tests.
    ///</summary>
    [TestClass]
    public class DemoModeServiceTest
    {
        ///<summary>
        ///  A test for DemoModeService Constructor.
        ///</summary>
        [TestMethod]
        public void DemoModeServiceConstructorTest()
        {
            var t = TimeSpan.FromDays(1);
            var player = new PlayerMock();
            var demoModeConfig = new DemoModeConfig(new[] {Colors.Red, Colors.Blue}, t, t, t, t, t);
            var service = new DemoModeService(player, demoModeConfig);
            player.TriggerSkeletonChangedEvent();
            Assert.IsNotNull(service.CurrentBackgroundColor);
            Assert.AreEqual(VideoWallState.Active, service.State);
        }
    }
}
