using System;
using System.Windows.Media;
using VideoWall.ResourceLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Controls;

// Test methods do not need to be documented by a comment

namespace VideoWall.Tests
{
    /// <summary>
    ///This is a test class for ResourceProviderTest and is intended
    ///to contain all ResourceProviderTest Unit Tests
    ///</summary>
    [TestClass]
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
        /// The ResourceProvider needs to access resources with the url scheme "pack://...". Therefore
        /// an application is needed.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            if (!UriParser.IsKnownScheme("pack")) new Application();
        }

        /// <summary>
        ///A test for GetResources
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void GetResourcesTest()
        {
            var actual = ResourceProvider_Accessor.GetResources();
            Assert.AreSame(ResourceProvider_Accessor.ResourceDictionary, actual);
        }

        /// <summary>
        ///A test for Image
        ///</summary>
        [TestMethod()]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void ImageTest()
        {
            //TODO: wie kann ich die Bilder vergleichen?
            //            const string key = "handRight";
            //            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_right.png";
            //            var expected = new Image {Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource};
            //            var actual = ResourceProvider_Accessor.Image(key);
            //            Assert.AreEqual(60, actual.Source.Width);
            //            Assert.AreEqual(60, actual.Source.Height);
        }

        /// <summary>
        ///A test for HandLeft
        ///</summary>
        [TestMethod()]
        public void HandLeftTest()
        {
            //TODO: wie kann ich die Bilder vergleichen?
            //            Image actual = ResourceProvider.HandLeft;
            //            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_left.png";
            //            var expected = new Image { Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource };
            //            Assert.AreEqual(expected,actual);
        }

        /// <summary>
        ///A test for HandRight
        ///</summary>
        [TestMethod]
        public void HandRightTest()
        {
            //TODO: wie kann ich die Bilder vergleichen?
            //            Image actual = ResourceProvider.HandRight;
            //            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_right.png";
            //            var expected = new Image { Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource };
            //            Assert.AreEqual(expected, actual);
        }
    }
}

