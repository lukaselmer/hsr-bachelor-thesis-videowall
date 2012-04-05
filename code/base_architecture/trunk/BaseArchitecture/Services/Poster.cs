using System.IO;
using System.Windows.Media.Imaging;

namespace Services
{
    public class Poster
    {
        public Poster(string fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            Image = new BitmapImage();
            Image.BeginInit();
            Image.StreamSource = File.OpenRead(fileName);
            Image.CacheOption = BitmapCacheOption.OnLoad;
            Image.EndInit();
            Image.Freeze();
        }
        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
    }
}
