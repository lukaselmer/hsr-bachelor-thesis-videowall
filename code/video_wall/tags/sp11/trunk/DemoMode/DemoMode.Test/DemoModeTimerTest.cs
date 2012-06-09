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
        ///A test for OnDemoModeTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void OnDemoModeTimerTickTest()
        {
            var target = new ModeTimer_Accessor();
            target.OnDemoModeTimerTick(null, null);
            Assert.IsTrue(target.IsInInteractionMode);
        }

        /// <summary>
        ///A test for OnInteractionModeTimerTick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void OnInteractionModeTimerTickTest()
        {
            var target = new ModeTimer_Accessor();
            target.OnInteractionModeTimerTick(null, null);
            Assert.IsFalse(target.IsInInteractionMode);
        }

        /// <summary>
        ///A test for WasSkeletonChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void SkeletonWasChangedTest()
        {
            var target = new ModeTimer_Accessor();
            target.SkeletonChanged();
            Assert.IsTrue(target.WasSkeletonChanged());
        }

        /// <summary>
        ///A test for WasSkeletonChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DemoMode.dll")]
        public void SkeletonWasNotChangedTest()
        {
            var target = new ModeTimer_Accessor();
            Assert.IsFalse(target.WasSkeletonChanged());
        }
    }
}
