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

using LunchMenuApp.ServiceModels.Implementation;
using LunchMenuApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.ViewModels
{
    ///<summary>
    ///  This is a test class for DishViewModelTest and is intended to contain all DishViewModelTest Unit Tests.
    ///</summary>
    [TestClass]
    public class DishViewModelTest
    {
        ///<summary>
        ///  A test for DishViewModel Constructor.
        ///</summary>
        [TestMethod]
        public void DishViewModelConstructorTest()
        {
            const string type = "type";
            const string name = "name";
            const string price = "price";
            var dish = new Dish(type, name, price);
            var vm = new DishViewModel(dish);
            Assert.AreSame(type, vm.Type);
            Assert.AreSame(name, vm.Name);
            Assert.AreSame(price, vm.Price);
        }
    }
}
