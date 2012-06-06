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
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.ServiceModels
{
    ///<summary>
    ///  This is a test class for DishTest and is intended to contain all DishTest Unit Tests
    ///</summary>
    [TestClass]
    public class DishTest
    {
        ///<summary>
        ///  A test for Dish Constructor
        ///</summary>
        [TestMethod]
        public void DishConstructorTest()
        {
            const string type = "Mittagsmenu";
            const string name = "Fleischerzeugnis";
            const string price = "CHF 80";
            var dish = new Dish(type, name, price);
            Assert.AreEqual(type, dish.Type);
            Assert.AreEqual(name, dish.Name);
            Assert.AreEqual(price, dish.Price);
        }
    }
}
