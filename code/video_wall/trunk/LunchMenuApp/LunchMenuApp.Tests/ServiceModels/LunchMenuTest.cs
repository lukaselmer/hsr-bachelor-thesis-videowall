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
using LunchMenuApp.ServiceModels.Implementation;
using LunchMenuApp.ServiceModels.Interfaces;
using LunchMenuApp.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.ServiceModels
{
    ///<summary>
    ///  This is a test class for LunchMenuTest and is intended to contain all LunchMenuTest Unit Tests.
    ///</summary>
    [TestClass]
    public class LunchMenuTest
    {
        ///<summary>
        ///  A test for LunchMenu Constructor.
        ///</summary>
        [TestMethod]
        public void LunchMenuConstructorTest()
        {
            const string date = "Freitag, 06.06.2012";
            var dishes = new List<IDish>();
            var mock = new LunchMenuParserMock {ExtractDateForTest = date, ExtractDishesForTest = dishes};
            var lunchMenu = new LunchMenu(new LunchMenuReaderMock().Html, mock);
            Assert.AreSame(date, lunchMenu.Date);
            Assert.AreSame(dishes, lunchMenu.Dishes);
        }

        ///<summary>
        ///  A test for LunchMenu Constructor.
        ///</summary>
        [TestMethod]
        public void LunchMenuConstructorTestWhenReaderThrows()
        {
            var mock = new LunchMenuParserMock {Throwing = true};
            try
            {
                new LunchMenu(new LunchMenuReaderMock().Html, mock);
            }
            catch (LunchMenuUnparsableException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }
    }
}
