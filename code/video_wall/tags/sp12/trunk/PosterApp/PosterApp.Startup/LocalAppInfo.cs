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
        #region Declarations

        private readonly UnityContainer _container;

        #endregion

        #region Constructors / Destructor

        public LocalAppInfo(string filepath)
        {
            _container = new UnityContainer();
            _container.RegisterInstance<IFileService>(new LocalFileService(filepath));
        }

        #endregion

        #region Methods

        public T GetExtension<T>() where T : IVideoWallService
        {
            return _container.Resolve<T>();
        }

        #endregion
    }
}
