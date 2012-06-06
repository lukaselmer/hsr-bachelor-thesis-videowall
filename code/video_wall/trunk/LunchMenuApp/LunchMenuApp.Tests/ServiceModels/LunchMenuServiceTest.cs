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
    ///  This is a test class for LunchMenuServiceTest and is intended to contain all LunchMenuServiceTest Unit Tests
    ///</summary>
    [TestClass]
    public class LunchMenuServiceTest
    {
        ///<summary>
        ///  A test for LunchMenuService Constructor
        ///</summary>
        [TestMethod]
        public void LunchMenuServiceConstructorTest()
        {
            const string date = "Freitag";
            var dishes = new List<IDish>();
            var lunchMenuParserMock = new LunchMenuParserMock { ExtractDateForTest = date, ExtractDishesForTest = dishes };
            var lunchMenuService = new LunchMenuService(new LunchMenuReaderMock(), lunchMenuParserMock);
            Assert.IsNotNull(lunchMenuService.LunchMenu);
            var menu = lunchMenuService.LunchMenu;
            Assert.AreSame(date, menu.Date);
            Assert.AreSame(dishes, menu.Dishes);
        }
        ///<summary>
        ///  A test for LunchMenuService Constructor
        ///</summary>
        [TestMethod]
        public void LunchMenuServiceConstructorTestWhenThrowing()
        {
            var lunchMenuService = new LunchMenuService(new LunchMenuReaderMock(), new LunchMenuParserMock { Throwing = true });
            Assert.IsNull(lunchMenuService.LunchMenu);
        }
    }
}
