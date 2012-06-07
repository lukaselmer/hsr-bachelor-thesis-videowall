using VideoWall.ViewModels.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;

namespace VideoWall.Tests.ViewModels
{
    /// <summary>
    ///This is a test class for MenuStyleViewModelTest and is intended
    ///to contain all MenuStyleViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuStyleViewModelTest
    {
        /// <summary>
        ///A test for MenuStyleViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void MenuStyleViewModelConstructorTest()
        {
            var fontColor = Colors.Red;
            var colorTop = Colors.Blue;
            var colorBottom = Colors.Yellow;
            var bottomLine = Colors.Green;
            var vm = new MenuStyleViewModel(fontColor, colorTop, colorBottom, bottomLine);
            Assert.AreEqual(fontColor, vm.FontColor);
            Assert.AreEqual(colorTop, vm.LightColor);
            Assert.AreEqual(colorBottom, vm.DarkColor);
            Assert.AreEqual(bottomLine, vm.BottomLineColor);
        }
    }
}
