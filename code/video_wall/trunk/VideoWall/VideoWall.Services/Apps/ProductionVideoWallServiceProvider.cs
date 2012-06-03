﻿#region Header

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
    public class ProductionVideoWallServiceProvider : IVideoWallServiceProvider
    {
        #region Declarations

        private readonly UnityContainer _appExtensionsContainer;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductionVideoWallServiceProvider"/> class.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="skeletonService">The skeleton service.</param>
        /// <param name="extensionsConfig">The extensions config.</param>
        public ProductionVideoWallServiceProvider(IApp app, ISkeletonService skeletonService, ExtensionsConfig extensionsConfig)
        {
            _appExtensionsContainer = new UnityContainer();

            // TODO: do this lazy
            _appExtensionsContainer.RegisterInstance<IFileService>(new FileService(app, extensionsConfig));
            _appExtensionsContainer.RegisterInstance(skeletonService);
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