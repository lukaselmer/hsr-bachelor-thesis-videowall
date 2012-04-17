using System.IO;
using System.Windows.Media.Imaging;

namespace Services
{
    public static class ImageExtension
    {
        /// <summary>
        /// Initializes the BitmapImage with the string.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static BitmapImage InitializeWith(this BitmapImage img, string fileName)
        {
            img.BeginInit();
            img.StreamSource = File.OpenRead(fileName);
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();
            img.Freeze();
            return img;
        }
    }
}
