using System.Windows.Media;
using System.Windows.Media.Imaging;
using VideoWall.ResourceLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;

namespace VideoWall.Tests
{
    
    
    /// <summary>
    ///This is a test class for ResourceProviderTest and is intended
    ///to contain all ResourceProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResourceProviderTest
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
        ///A test for GetResources
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void GetResourcesTest()
        {
            ResourceDictionary expected = null; // TODO: Initialize to an appropriate value
            ResourceDictionary actual;

            
            actual = ResourceProvider_Accessor.GetResources();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Image
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void ImageTest()
        {
            //TODO: uääääääääääääääääääääääääh :'(
            const string key = "handRight";
            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_right.png";
            var expected = new Image {Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource};
            var actual = ResourceProvider_Accessor.Image(key);
            //Assert.AreEqual(60, actual.Source.Width);
            Assert.AreEqual(60, actual.Source.Height);
        }



        /// <summary>
        ///A test for HandLeft
        ///</summary>
        [TestMethod()]
        public void HandLeftTest()
        {
            var actual = ResourceProvider.HandLeft;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for HandRight
        ///</summary>
        [TestMethod()]
        public void HandRightTest()
        {
            var actual = ResourceProvider.HandRight;
            Assert.IsNotNull(actual);
        }
    }
}
