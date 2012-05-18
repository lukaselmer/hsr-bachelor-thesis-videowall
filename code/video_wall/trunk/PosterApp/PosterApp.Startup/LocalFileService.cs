using VideoWall.Interfaces;

namespace PosterApp.Startup
{
    public class LocalFileService : IFileService
    {
        public LocalFileService(string directory)
        {
            ResourceDirectory = directory;
        }

        public string ResourceDirectory { get; private set; }
    }
}