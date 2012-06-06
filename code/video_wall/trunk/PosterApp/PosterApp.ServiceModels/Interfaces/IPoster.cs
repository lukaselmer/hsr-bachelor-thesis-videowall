using System.Windows.Media.Imaging;

namespace PosterApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The poster interface.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IPoster
    {
        /// <summary>
        ///   Gets the image.
        /// </summary>
        BitmapImage Image { get; }
    }
}