using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    /// The file service provides a directory where an exension has read and write access
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="app">The app.</param>
        public FileService(IApp app)
        {
            ResourceDirectory = ExtensionManager.InitApp(app);
        }

        /// <summary>
        /// Gets the resource directory.
        /// </summary>
        public string ResourceDirectory { get; private set; }
    }
}