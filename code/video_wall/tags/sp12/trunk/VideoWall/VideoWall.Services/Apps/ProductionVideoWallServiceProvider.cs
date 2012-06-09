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

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   The AppInfo for a application which runs on the video wall.
    /// </summary>
    public class ProductionVideoWallServiceProvider : IVideoWallServiceProvider
    {
        #region Declarations

        private readonly UnityContainer _appExtensionsContainer;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProductionVideoWallServiceProvider" /> class.
        /// </summary>
        /// <param name="app"> The app. </param>
        public ProductionVideoWallServiceProvider(IApp app)
        {
            _appExtensionsContainer = new UnityContainer();

            // TODO: do this lazy
            _appExtensionsContainer.RegisterInstance<IFileService>(new FileService(app));
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Gets the extension. Similar: Extension Interface Pattern.
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <returns> </returns>
        public T GetExtension<T>() where T : IVideoWallService
        {
            return _appExtensionsContainer.Resolve<T>();
        }

        #endregion
    }
}