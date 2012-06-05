#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using HtmlAgilityPack;
using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.Helpers;

#endregion

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    /// The lunch menu parser parses a html document.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class LunchMenuParser
    {
        #region Declarations

        /// <summary>
        /// The document.
        /// </summary>
        private readonly HtmlDocument _document;

        /// <summary>
        /// The menu node
        /// </summary>
        private readonly HtmlNode _menuNode;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Parses the dishes and the menu date from the html
        /// </summary>
        /// ///
        /// <param name="html"> The html. </param>
        internal LunchMenuParser(string html)
        {
            PreOrPostCondition.AssertNotNullOrEmpty(html, "html");
            _document = new HtmlDocument();
            _document.LoadHtml(html);
            _menuNode = LoadMenuContent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Loads the content of the menu.
        /// </summary>
        /// <returns> </returns>
        private HtmlNode LoadMenuContent()
        {
            return _document.DocumentNode.SelectSingleNode(@"//div[@class='menu-plan-content']");
        }

        /// <summary>
        ///   Extracts the date.
        /// </summary>
        /// <returns> </returns>
        internal string ExtractDate()
        {
            return _menuNode.SelectSingleNode(@"div[@class='date']/h2").InnerText;
        }

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> </returns>
        internal List<IDish> ExtractDishes()
        {
            return new DishParser(_menuNode.SelectNodes(@"div[@class='offer']")).ExtractDishes();
        }

        #endregion
    }
}