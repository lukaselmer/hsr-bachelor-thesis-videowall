using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Common;
using System.Windows.Media.Imaging;

namespace Services
{
    public class LunchMenu
    {
        public LunchMenu(string fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            Image = new BitmapImage();
            Image.BeginInit();
            Image.StreamSource = File.OpenRead(fileName);
            Image.EndInit();
            Image.Freeze();
        }

        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
    }
}
