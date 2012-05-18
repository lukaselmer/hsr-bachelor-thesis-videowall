using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchMenuApp.ServiceModels
{
    public class Dish
    {
        public Dish(string type, string name, string price)
        {
            Type = type;
            Name = name;
            Price = price;
        }

        public string Type { get; private set; }
        public string Name { get; private set; }
        public string Price { get; private set; }
    }
}
