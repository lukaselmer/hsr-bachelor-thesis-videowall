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
using Common;
using HtmlAgilityPack;

#endregion

namespace LunchMenuApp.ServiceModels
{
    internal class LunchMenuParser
    {
        private readonly HtmlNode _menuNode;

        /// <summary>
        /// Parses the dishes and the menu date from the html
        /// </summary>
        /// /// <param name="html">The html.</param>
        internal LunchMenuParser(string html)
        {
            //TODO: notNullOrEmpty
            PreOrPostCondition.AssertNotNull(html, "html");
            var document = new HtmlDocument();
            document.LoadHtml(html);
            _menuNode = LoadMenuContent(document);
        }

        private HtmlNode LoadMenuContent(HtmlDocument document)
        {
            PreOrPostCondition.AssertNotNull(document, "document");
            return document.DocumentNode.SelectSingleNode(@"//div[@class='menu-plan-content']");
        }

        internal string ExtractDate()
        {
            return _menuNode.SelectSingleNode(@"div[@class='date']/h2").InnerText;
        }

        internal List<Dish> ExtractMenus()
        {
            var dishParser = new DishParser(_menuNode.SelectNodes(@"div[@class='offer']"));
            return dishParser.ExtractDishes();
        }
    }

    internal class DishParser
    {
        private readonly HtmlNodeCollection _nodes;

        /// <summary>
        /// Extracts and parses the dishes.
        /// </summary>
        public DishParser(HtmlNodeCollection nodes)
        {
            PreOrPostCondition.AssertNotNull(nodes, "nodes");
            _nodes = nodes;
        }

        public List<Dish> ExtractDishes()
        {
            return _nodes.Where(HasPrice).Select(ParseDish).ToList();
        }

        private bool HasPrice(HtmlNode node)
        {
            return node.SelectSingleNode("div[@class='price']") != null;
        }

        private Dish ParseDish(HtmlNode node)
        {
            var type = node.SelectSingleNode("div[@class='offer-description']").InnerText.Trim();
            var name = node.SelectSingleNode("div[@class='menu-description']").InnerText.Trim();
            var price = node.SelectSingleNode("div[@class='price']").InnerText.Trim();
            return new Dish(type, name, price);
        }
    }
}