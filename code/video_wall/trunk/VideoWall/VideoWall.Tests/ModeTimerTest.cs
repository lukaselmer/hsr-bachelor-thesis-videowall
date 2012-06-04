using System.Windows.Media;
using VideoWall.ServiceModels.DemoMode;
using VideoWall.ViewModels.DemoMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VideoWall.Tests
{


    /// <summary>
    ///This is a test class for ModeTimerTest and is intended
    ///to contain all ModeTimerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ModeTimerTest
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
        ///A test for ModeTimer Constructor
        ///</summary>
        [TestMethod]
        public void ModeTimerConstructorTest()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            Assert.IsTrue(target.IsInInteractionMode);

            Assert.IsTrue(target.ToDemoModeTimer.IsEnabled);
            Assert.IsFalse(target.ToInteractionModeTimer.IsEnabled);

            Assert.IsTrue(target.SkeletonCheckTimer.IsEnabled);
            Assert.IsFalse(target.FastSkeletonCheckTimer.IsEnabled);

            Assert.IsFalse(target.ChangeAppTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnFastSkeletonCheckTimerTick with unchanged skeleton
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnFastSkeletonCheckTimerTickTestWithUnchangedSkeleton()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            Assert.IsFalse(target.WasSkeletonChanged());
            target.OnFastSkeletonCheckTimerTick(null, null);
            Assert.IsTrue(target.ToInteractionModeTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnFastSkeletonCheckTimerTick with changed skeleton
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnFastSkeletonCheckTimerTickTestWithChangedSkeleton()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            target.SkeletonChanged();
            Assert.IsTrue(target.WasSkeletonChanged());
            target.OnFastSkeletonCheckTimerTick(null, null);
            Assert.IsTrue(target.SkeletonCheckTimer.IsEnabled);
            Assert.IsFalse(target.FastSkeletonCheckTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnSkeletonCheckTimerTick when in demo mode and with unchanged skeleton
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnSkeletonCheckTimerTickTestInDemoModeWithUnchangedSkeleton()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock()) { IsInInteractionMode = false };
            Assert.IsFalse(target.WasSkeletonChanged());
            target.OnSkeletonCheckTimerTick(null, null);
            Assert.IsTrue(target.ChangeAppTimer.IsEnabled);
            Assert.IsTrue(target.FastSkeletonCheckTimer.IsEnabled);
            Assert.IsFalse(target.SkeletonCheckTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnSkeletonCheckTimerTick when in demo mode and with changed skeleton
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnSkeletonCheckTimerTickTestInDemoModeWithChangedSkeleton()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock()) { IsInInteractionMode = false };
            target.SkeletonChanged();
            Assert.IsTrue(target.WasSkeletonChanged());
            target.OnSkeletonCheckTimerTick(null, null);
            Assert.IsFalse(target.ChangeAppTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnToDemoModeTimerTick
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnToDemoModeTimerTickTest()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            target.OnToDemoModeTimerTick(null, null);

            Assert.IsFalse(target.IsInInteractionMode);

            Assert.IsTrue(target.ToInteractionModeTimer.IsEnabled);
            Assert.IsFalse(target.ToDemoModeTimer.IsEnabled);

            Assert.IsFalse(target.SkeletonCheckTimer.IsEnabled);
            Assert.IsTrue(target.FastSkeletonCheckTimer.IsEnabled);

            Assert.IsTrue(target.ChangeAppTimer.IsEnabled);
        }

        /// <summary>
        ///A test for OnToInteractionModeTimerTick
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ViewModels.dll")]
        public void OnToInteractionModeTimerTickTest()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            target.OnToInteractionModeTimerTick(null, null);

            Assert.IsTrue(target.IsInInteractionMode);

            Assert.IsTrue(target.ToDemoModeTimer.IsEnabled);
            Assert.IsFalse(target.ToInteractionModeTimer.IsEnabled);

            Assert.IsTrue(target.SkeletonCheckTimer.IsEnabled);
            Assert.IsFalse(target.FastSkeletonCheckTimer.IsEnabled);

            Assert.IsFalse(target.ChangeAppTimer.IsEnabled);
        }

        /// <summary>
        ///A test for SkeletonChangedEvent
        ///</summary>
        [TestMethod]
        public void SkeletonChangedTest()
        {
            var target = new ModeTimer_Accessor(new DemoModeConfigMock());
            Assert.IsFalse(target.WasSkeletonChanged());
            target.SkeletonChanged();
            Assert.IsTrue(target.WasSkeletonChanged());
        }
    }

    /// <summary>
    /// The demo mode config mock for the tests
    /// </summary>
    class DemoModeConfigMock : DemoModeConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeConfigMock"/> class.
        /// </summary>
        public DemoModeConfigMock()
            : base(new[] { Colors.Red, Colors.Blue },
            TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100),
            TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100))
        {
        }
    }
}
