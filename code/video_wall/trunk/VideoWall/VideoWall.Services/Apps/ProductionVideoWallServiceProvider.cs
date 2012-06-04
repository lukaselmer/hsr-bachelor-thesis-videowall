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

using System;
using Microsoft.Practices.Unity;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player;

#endregion

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   The AppInfo for a application which runs on the video wall.
    /// </summary>
    internal class ProductionVideoWallServiceProvider : IVideoWallServiceProvider
    {
        #region Declarations

        private readonly UnityContainer _appExtensionsContainer;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionVideoWallServiceProvider"/> class.
        /// </summary>
        /// <param name="extensionFolder">The extension folder.</param>
        /// <param name="extensionsConfig">The extensions config.</param>
        /// <param name="player">The player.</param>
        public ProductionVideoWallServiceProvider(ExtensionFolder extensionFolder, Player.Player player)
        {
            _appExtensionsContainer = new UnityContainer();

            _appExtensionsContainer.RegisterInstance(extensionFolder);
            _appExtensionsContainer.RegisterInstance(player);

            _appExtensionsContainer.RegisterType<IFileService, FileService>();
            _appExtensionsContainer.RegisterType<ISkeletonService, SkeletonService>();
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