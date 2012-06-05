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
using System.Linq;
using HtmlAgilityPack;
using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.Helpers;

#endregion

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    ///   Parses the dishes from html nodes
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class DishParser
    {
        #region Declarations

        /// <summary>
        /// The HTML nodes
        /// </summary>
        private readonly HtmlNodeCollection _nodes;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Extracts and parses the dishes.
        /// </summary>
        public DishParser(HtmlNodeCollection nodes)
        {
            PreOrPostCondition.AssertNotNull(nodes, "nodes");
            _nodes = nodes;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Extracts the dishes.
        /// </summary>
        /// <returns> </returns>
        public List<IDish> ExtractDishes()
        {
            return _nodes.Where(HasPrice).Select(ParseDish).ToList();
        }

        /// <summary>
        ///   Determines whether the specified node has price.
        /// </summary>
        /// <param name="node"> The node. </param>
        /// <returns> <c>true</c> if the specified node has price; otherwise, <c>false</c> . </returns>
        private static bool HasPrice(HtmlNode node)
        {
            return node.SelectSingleNode("div[@class='price']") != null;
        }

        /// <summary>
        ///   Parses and creates the dish from an html node.
        /// </summary>
        /// <param name="node"> The node. </param>
        /// <returns> </returns>
        private static IDish ParseDish(HtmlNode node)
        {
            var type = node.SelectSingleNode("div[@class='offer-description']").InnerText.Trim();
            var name = node.SelectSingleNode("div[@class='menu-description']").InnerText.Trim();
            var price = node.SelectSingleNode("div[@class='price']").InnerText.Trim();
            return new Dish(type, name, price);
        }

        #endregion
    }
}