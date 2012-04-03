using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Services
{
    public class Poster
    {
        public Poster(string fileName)
        {
            var fileNameWihoutExtension = Path.GetFileNameWithoutExtension(fileName);
            Name = fileNameWihoutExtension;
            Image = new BitmapImage();
            Image.BeginInit();
            Image.StreamSource = File.OpenRead(fileName);
            Image.EndInit();
        }
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
    }
}
