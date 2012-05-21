#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using Microsoft.Practices.Unity;
using VideoWall.Interfaces;

#endregion

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

        #region IVideoWallServiceProvider Members

        public T GetExtension<T>() where T : IVideoWallService
        {
            return _container.Resolve<T>();
        }

        #endregion
    }
}
