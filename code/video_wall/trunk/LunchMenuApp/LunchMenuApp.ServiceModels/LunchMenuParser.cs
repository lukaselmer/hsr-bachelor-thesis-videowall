using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using LunchMenuApp.ServiceModels;

namespace ServiceModels
{
    internal class LunchMenuParser
    {
        private readonly HtmlNode _menuNode;

        /// <summary>
        /// Parses the dishes and the menu date from the html
        /// </summary>
        /// <param name="html"></param>
        internal LunchMenuParser(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            _menuNode = LoadMenuContent(document);
        }

        private HtmlNode LoadMenuContent(HtmlDocument document)
        {
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

        public DishParser(HtmlNodeCollection nodes)
        {
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
            string type = node.SelectSingleNode("div[@class='offer-description']").InnerText.Trim();
            string name = node.SelectSingleNode("div[@class='menu-description']").InnerText.Trim();
            string price = node.SelectSingleNode("div[@class='price']").InnerText.Trim();
            return new Dish(type, name, price);
        }
    }
}