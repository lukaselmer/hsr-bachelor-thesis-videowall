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

using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosterApp.ServiceModels.Interfaces;
using PosterApp.Tests.Mocks;
using PosterApp.ViewModels;

#endregion

namespace PosterApp.Tests.ViewModels
{
    ///<summary>
    ///  This is a test class for PosterViewModelTest and is intended to contain all PosterViewModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class PosterViewModelTest
    {
        ///<summary>
        ///  A test for PosterViewModel Constructor
        ///</summary>
        [TestMethod]
        public void PosterViewModelConstructorTest()
        {
            IPosterService posterService = new PosterServiceMock();
            var vm = new PosterViewModel_Accessor(posterService);
            Assert.IsNotNull(vm.CurrentPoster);
            Assert.IsNotNull(vm.Posters);
            Assert.IsNotNull(vm.NavigateToLeftCommand);
            Assert.IsNotNull(vm.NavigateToRightCommand);
            Assert.AreSame(vm.Posters[0], vm.CurrentPoster);
        }

        ///<summary>
        ///  A test for NavigateToLeftCommand
        ///</summary>
        [TestMethod]
        public void NavigateToLeftCommandTest()
        {
            IPosterService posterService = new PosterServiceMock();
            var vm = new PosterViewModel_Accessor(posterService);

            Assert.AreEqual(3, vm.Posters.Count);
            Assert.AreSame(vm.Posters[0], vm.CurrentPoster);
            vm.NavigateToLeftCommand.Execute(null);
            Assert.AreSame(vm.Posters[2], vm.CurrentPoster);
            vm.NavigateToLeftCommand.Execute(null);
            Assert.AreSame(vm.Posters[1], vm.CurrentPoster);
            vm.NavigateToLeftCommand.Execute(null);
            Assert.AreSame(vm.Posters[0], vm.CurrentPoster);

        }

        ///<summary>
        ///  A test for NavigateToRightCommand
        ///</summary>
        [TestMethod]
        public void NavigateToRightCommandTest()
        {
            IPosterService posterService = new PosterServiceMock();
            var vm = new PosterViewModel_Accessor(posterService);

            Assert.AreEqual(3, vm.Posters.Count);
            Assert.AreSame(vm.Posters[0], vm.CurrentPoster);
            vm.NavigateToRightCommand.Execute(null);
            Assert.AreSame(vm.Posters[1], vm.CurrentPoster);
            vm.NavigateToRightCommand.Execute(null);
            Assert.AreSame(vm.Posters[2], vm.CurrentPoster);
            vm.NavigateToRightCommand.Execute(null);
            Assert.AreSame(vm.Posters[0], vm.CurrentPoster);
        }
    }
}
