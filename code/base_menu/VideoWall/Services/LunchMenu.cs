using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Services
{
    class LunchMenu
    {
        public LunchMenu(string name, BitmapImage image)
        {
            Name = name;
            Image = image;
        }
        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
    }
}
