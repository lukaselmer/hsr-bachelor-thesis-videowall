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

using System;
using LunchMenuApp.ServiceModels.Implementation;
using LunchMenuApp.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace LunchMenuApp.Tests.ServiceModels
{
    ///<summary>
    ///  This is a test class for LunchMenuParserTest and is intended to contain all LunchMenuParserTest Unit Tests.
    ///</summary>
    [TestClass]
    public class LunchMenuParserTest
    {
        ///<summary>
        ///  A test for LunchMenuParser Constructor.
        ///</summary>
        [TestMethod]
        public void LunchMenuParserConstructorTest()
        {
            var parser = new LunchMenuParser_Accessor {Html = new LunchMenuReaderMock().Html};
            Assert.IsNotNull(parser._menuNode);
        }

        ///<summary>
        ///  A test for LunchMenuParser Constructor.
        ///</summary>
        [TestMethod]
        public void LunchMenuParserConstructorTestWrongHtml()
        {
            try
            {
                var parser = new LunchMenuParser {Html = "blabla"};
                parser.ExtractDate();
                parser.ExtractDishes();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false, "Exception should have been thrown.");
        }

        ///<summary>
        ///  A test for LunchMenuParser Constructor.
        ///</summary>
        [TestMethod]
        public void LunchMenuParserConstructorTestWrongContent()
        {
            try
            {
                var parser = new LunchMenuParser {Html = "<html></html>"};
                parser.ExtractDate();
                parser.ExtractDishes();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false, "Exception should have been thrown.");
        }

        ///<summary>
        ///  A test for ExtractDate.
        ///</summary>
        [TestMethod]
        public void ExtractDateTest()
        {
            var parser = new LunchMenuParser {Html = new LunchMenuReaderMock().Html};
            Assert.AreEqual("Freitag, 18.05.2012", parser.ExtractDate());
        }

        ///<summary>
        ///  A test for ExtractDishes.
        ///</summary>
        [TestMethod]
        public void ExtractMenusTest()
        {
            var parser = new LunchMenuParser {Html = new LunchMenuReaderMock().Html};
            var dishes = parser.ExtractDishes();

            Assert.AreEqual(4, dishes.Count);

            // Test dish #1
            Assert.AreEqual("Tagesteller", dishes[0].Type);
            Assert.AreEqual(@"Thai-Fischröllchen
auf Wokgemüse
Sweet & Sour
Jasminreis
Fisch das Dänemark/Pazifik", dishes[0].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[0].Price);

            // Test dish #2
            Assert.AreEqual("Vegetarisch", dishes[1].Type);
            Assert.AreEqual(@"Kartoffelquarktaschen mit 
Wokgemüse
und Tomatensauce

Menüsalat", dishes[1].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[1].Price);

            // Test dish #3
            Assert.AreEqual("Täglich im Angebot", dishes[2].Type);
            Assert.AreEqual(@"Dauerbrenner 

Rinds-Hamburger 
(Schweiz)
mit Barbeque-Sauce", dishes[2].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[2].Price);

            // Test dish #4
            Assert.AreEqual("Wochen-Hit", dishes[3].Type);
            Assert.AreEqual(@"Portion Spargel
aus Flaach von 
der Familie Spaltenstein
mit Sauce Hollandaise
und Kräuterkartoffeln
Menüsalat", dishes[3].Name);
            Assert.AreEqual("INT 14.50 EXT 15.50", dishes[3].Price);
        }
    }
}
