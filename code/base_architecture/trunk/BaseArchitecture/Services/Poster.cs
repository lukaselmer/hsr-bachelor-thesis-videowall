using System.IO;
using System.Windows.Media.Imaging;

namespace Services
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class Poster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Poster"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public Poster(string fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            Image = new BitmapImage();
            Image.InitializeWith(fileName);
        }

        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
    }
}
