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
    /// <summary>
    /// The local app info.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class LocalAppInfo : IVideoWallServiceProvider
    {
        #region Declarations

        /// <summary>
        /// TODO: doc this
        /// </summary>
        private readonly UnityContainer _container;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalAppInfo"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public LocalAppInfo(string filepath)
        {
            _container = new UnityContainer();
            _container.RegisterInstance<IFileService>(new LocalFileService(filepath));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExtension<T>() where T : IVideoWallService
        {
            return _container.Resolve<T>();
        }

        #endregion
    }
}
