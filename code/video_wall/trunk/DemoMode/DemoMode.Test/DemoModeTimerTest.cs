using DemoMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DemoMode.Test
{
    
    
    /// <summary>
    ///This is a test class for DemoModeTimerTest and is intended
    ///to contain all DemoModeTimerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DemoModeTimerTest
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
        ///A test for OnSecondTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void OnSecondTimerTickTest()
        {
            var target = new DemoModeTimer_Accessor();
            var progress = target.Progress;
            target.OnSecondTimerTick(null, null);
            Assert.AreEqual(progress - 1, target.Progress);
        }

        /// <summary>
        ///A test for OnTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void OnTimerTickTest()
        {
            var target = new DemoModeTimer_Accessor();
            Assert.IsTrue(target.IsInInteractionMode);
            target.OnTimerTick(null, null);
            Assert.IsFalse(target.IsInInteractionMode);
        }

        /// <summary>
        ///A test for SkeletonWasChanged
        ///</summary>
        [TestMethod()]
        public void SkeletonWasChangedTest()
        {
            var target = new DemoModeTimer_Accessor();
            target.SkeletonWasChanged();
            Assert.IsTrue(target.IsInInteractionMode);
            Assert.AreEqual(DemoModeTimer_Accessor.Interval, target.Progress);
        }
    }
}
