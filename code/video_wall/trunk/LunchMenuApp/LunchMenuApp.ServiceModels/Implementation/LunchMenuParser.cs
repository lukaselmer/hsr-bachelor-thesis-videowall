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
using HtmlAgilityPack;
using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.Helpers;

#endregion

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The lunch menu parser parses a html document.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class LunchMenuParser : ILunchMenuParser
    {
        #region Declarations

        /// <summary>
        ///   The document.
        /// </summary>
        private HtmlDocument _document;

        /// <summary>
        ///   The menu node
        /// </summary>
        private HtmlNode _menuNode;

        #endregion

        #region Properties

        /// <summary>
        ///   Sets the HTML to be parsed.
        /// </summary>
        /// <value> The HTML. </value>
        public string Html
        {
            set
            {
                PreOrPostCondition.AssertNotNullOrEmpty(value, "Html value");
                _document = new HtmlDocument();
                _document.LoadHtml(value);
                _menuNode = LoadMenuContent();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Extracts the date.
        /// </summary>
        /// <returns> The date. </returns>
        public string ExtractDate()
        {
            return _menuNode.SelectSingleNode(@"div[@class='date']/h2").InnerText;
        }

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> The dishes. </returns>
        public List<IDish> ExtractDishes()
        {
            return new DishParser(_menuNode.SelectNodes(@"div[@class='offer']")).ExtractDishes();
        }

        /// <summary>
        ///   Loads the content of the menu.
        /// </summary>
        /// <returns> The menu node. </returns>
        private HtmlNode LoadMenuContent()
        {
            return _document.DocumentNode.SelectSingleNode(@"//div[@class='menu-plan-content']");
        }

        #endregion
    }
}
