using Microsoft.Practices.Unity;
using VideoWall.Interfaces;

namespace PosterApp.Startup
{
    public class LocalAppInfo : IVideoWallServiceProvider
    {
        private readonly UnityContainer _container;

        public LocalAppInfo(string filepath)
        {
            _container = new UnityContainer();
            _container.RegisterInstance<IFileService>(new LocalFileService(filepath));
        }

        public T GetExtension<T>() where T : IVideoWallService
        {
            return _container.Resolve<T>();
        }
    }
}