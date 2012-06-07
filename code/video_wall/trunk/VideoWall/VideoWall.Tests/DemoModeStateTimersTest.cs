using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoWall.ServiceModels.DemoMode.Interfaces;
using VideoWall.Tests.Mocks;

namespace VideoWall.Tests
{


    /// <summary>
    ///This is a test class for DemoModeStateTimersTest and is intended
    ///to contain all DemoModeStateTimersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DemoModeStateTimersTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for DemoModeStateTimers Constructor
        ///</summary>
        [TestMethod()]
        public void DemoModeStateTimersConstructorTest()
        {
            var t = TimeSpan.FromDays(1);
            var demoModeConfig = new DemoModeConfig(new[] { Colors.Red, Colors.Blue }, t, t, t, t, t);
            var timers = new DemoModeStateTimers_Accessor(demoModeConfig);
            var before = timers._lastSkeletonTime;
            timers.SkeletonChanged();
            Assert.IsTrue(before < timers._lastSkeletonTime);
        }

        /// <summary>
        /// Changeds the status method test.
        /// </summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ServiceModels.dll")]
        public void ChangedStatusMethodTest()
        {
            var t = TimeSpan.FromDays(1);
            var demoModeConfig = new DemoModeConfig(new[] { Colors.Red, Colors.Blue }, t, t, t, t, t);
            var timers = new DemoModeStateTimers_Accessor(demoModeConfig);
            timers._state = VideoWallState.Teaser;
            timers._lastSkeletonTime = DateTime.Now;
            var changed = false;
            timers.add_DemoModeStateChanged(delegate { changed = true; });
            timers.CheckAndChangeState(this, null);
            Assert.IsTrue(changed);
            Assert.AreEqual(VideoWallState.Countdown, timers.State);
            Assert.IsNotNull(timers.Countdown);
        }

        /// <summary>
        ///A test for AppChangedMethod
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ServiceModels.dll")]
        public void AppChangedMethodTest()
        {
            var t = TimeSpan.FromDays(1);
            var demoModeConfig = new DemoModeConfig(new[] { Colors.Red, Colors.Blue }, t, t, t, t, t);
            var timers = new DemoModeStateTimers_Accessor(demoModeConfig);
            timers._state = VideoWallState.Teaser;
            var changed = false;
            timers.add_AppChanged(delegate { changed = true; });
            timers.AppChangedMethod(this, null);
            Assert.IsTrue(changed);
        }
    }
}
