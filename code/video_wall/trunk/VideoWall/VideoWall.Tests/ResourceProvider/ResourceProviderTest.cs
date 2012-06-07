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

using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.ResourceLoader;
#endregion

namespace VideoWall.Tests.ResourceProvider
{
    ///<summary>
    ///  This is a test class for ResourceProviderTest and is intended to contain all ResourceProviderTest Unit Tests.
    ///</summary>
    [TestClass]
    public class ResourceProviderTest
    {
        ///<summary>
        ///  A test for GetResources.
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void GetResourcesTest()
        {
            new Application();
            var actual = ResourceProvider_Accessor.GetResources();
            Assert.AreSame(ResourceProvider_Accessor.ResourceDictionary.Value, actual);
        }

        ///<summary>
        ///  A test for Image.
        ///</summary>
        [TestMethod]
        [DeploymentItem("VideoWall.ResourceLoader.dll")]
        public void ImageTest()
        {
            const string key = "handRight";
            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_right.png";
            var expected = new Image {Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource};
            var actual = ResourceProvider_Accessor.Image(key);
            Assert.IsTrue(TestImageEquality(expected, actual), "Images are not equal.");
        }

        ///<summary>
        ///  A test for the left hand.
        ///</summary>
        [TestMethod]
        public void HandLeftTest()
        {
            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_left.png";
            var expected = new Image { Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource };
            var actual = ResourceLoader.ResourceProvider.HandLeft;
            Assert.IsTrue(TestImageEquality(expected, actual), "Images are not equal.");
        }

        ///<summary>
        ///  A test for the right hand.
        ///</summary>
        [TestMethod]
        public void HandRightTest()
        {
            const string packUri = "pack://application:,,,/VideoWall.ResourceLoader;component/Files/hand_right.png";
            var expected = new Image {Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource};
            var actual = ResourceLoader.ResourceProvider.HandRight;
            Assert.IsTrue(TestImageEquality(expected, actual), "Images are not equal.");
        }

        /// <summary>
        ///   Tests the image equality.
        /// </summary>
        /// <param name="a"> A. </param>
        /// <param name="b"> The b. </param>
        /// <returns> Weather the images are equal or not. </returns>
        private static bool TestImageEquality(Image a, Image b)
        {
            return a.Source.ToString() == b.Source.ToString();
        }
    }
}
