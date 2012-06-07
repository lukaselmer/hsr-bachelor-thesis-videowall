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

using System.Collections.Generic;
using System.Linq;
using LunchMenuApp.ServiceModels.Implementation;
using LunchMenuApp.ServiceModels.Interfaces;
using LunchMenuApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.ViewModels
{
    ///<summary>
    ///  This is a test class for LunchMenuViewModelTest and is intended to contain all LunchMenuViewModelTest Unit Tests.
    ///</summary>
    [TestClass]
    public class LunchMenuViewModelTest
    {
        /// <summary>
        ///   A lunch menu view model constructor test without lunch menu.
        /// </summary>
        [TestMethod]
        public void LunchMenuViewModelConstructorTestWithoutLunchMenu()
        {
            var vm = new LunchMenuViewModel(new LunchMenuServiceMock {LunchMenu = null});
            Assert.AreEqual("nicht verfügbar", vm.Title);
            Assert.AreEqual(0, vm.Dishes.Count);
        }

        /// <summary>
        ///   A lunch menu view model constructor test without lunch menu.
        /// </summary>
        [TestMethod]
        public void LunchMenuViewModelConstructorTest()
        {
            const string date = "Freitag";
            var dishes = new List<IDish>
                {
                    new Dish("type1", "name1", "price1"),
                    new Dish("type2", "name2", "price2")
                };
            var lunchMenuMock = new LunchMenuMock {Date = date, Dishes = dishes};
            var vm = new LunchMenuViewModel(new LunchMenuServiceMock {LunchMenu = lunchMenuMock});
            Assert.AreEqual(date, vm.Title);
            Assert.AreEqual(dishes.Count, vm.Dishes.Count);
            var dishesInVm = vm.Dishes.ToList();
            Assert.AreEqual(dishes[0].Name, dishesInVm[0].Name);
            Assert.AreEqual(dishes[0].Price, dishesInVm[0].Price);
            Assert.AreEqual(dishes[0].Type, dishesInVm[0].Type);
            Assert.AreEqual(dishes[1].Name, dishesInVm[1].Name);
            Assert.AreEqual(dishes[1].Price, dishesInVm[1].Price);
            Assert.AreEqual(dishes[1].Type, dishesInVm[1].Type);
        }


        /// <summary>
        ///   A lunch menu view model constructor test without lunch menu.
        /// </summary>
        [TestMethod]
        public void LunchMenuViewModelLunchMenuChangedTest()
        {
            const string date = "Freitag";
            var dishes = new List<IDish>
                {
                    new Dish("type1", "name1", "price1"),
                    new Dish("type2", "name2", "price2")
                };
            var lunchMenuMock = new LunchMenuMock {Date = date, Dishes = dishes};
            var lunchMenuServiceMock = new LunchMenuServiceMock {LunchMenu = lunchMenuMock};
            var vm = new LunchMenuViewModel(lunchMenuServiceMock);
            Assert.AreEqual(date, vm.Title);
            Assert.AreEqual(dishes.Count, vm.Dishes.Count);

            var newDishes = new List<IDish> {new Dish("new", "new", "new")};
            lunchMenuMock.Dishes = newDishes;
            lunchMenuServiceMock.OnLunchMenuChanged(this, null);
            Assert.AreEqual(newDishes.Count, vm.Dishes.Count);
            Assert.AreEqual(newDishes[0].Name, vm.Dishes.ToList()[0].Name);
        }
    }
}
