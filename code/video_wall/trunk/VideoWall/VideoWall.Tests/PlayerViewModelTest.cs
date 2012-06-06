using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoWall.Tests
{
    
    
    /// <summary>
    ///This is a test class for PlayerViewModelTest and is intended
    ///to contain all PlayerViewModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class PlayerViewModelTest
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
        ///A test for PlayerViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void PlayerViewModelConstructorTest()
        {
            // BUG: fix this test
            /*const string path = "..\\..\\..\\..\\..\\..\\kinect_records\\20120312_lukas\\_2.replay";
            ISkeletonReader isr = new AutoPlayFileSkeletonReader(new KinectReplayFile(path));
            var player = new Player(isr);
            var target = new PlayerViewModel(player);
            var accessor = new PlayerViewModel_Accessor(player);
            Assert.IsNotNull(target.Lines);
            Assert.AreEqual(160, target.WidthAndHeight);
            Assert.IsTrue(accessor._player.Playing);
            accessor.StopCommand.Execute(null);
            Assert.IsFalse(accessor._player.Playing);*/
        }
    }
}
