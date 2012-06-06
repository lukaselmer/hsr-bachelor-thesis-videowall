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
using System.Collections.Generic;
using System.Linq;
using VideoWall.Common.Exceptions;
using VideoWall.Common.Helpers;
using VideoWall.Common.Logging;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Apps.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   Controls the apps.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class AppController : IAppController
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        private readonly List<ExtensionFolder> _extensionFolders;
        private readonly IPlayer _player;

        #endregion

        #region Properties

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        public IEnumerable<IApp> Apps { get { return _extensionFolders.Where(ef => ef.IsLoaded()).Select(ef => ef.App); } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes the AppController.
        /// </summary>
        public AppController(IPlayer player, ExtensionsConfig extensionsConfig)
        {
            PreOrPostCondition.AssertNotNull(player, "player");
            PreOrPostCondition.AssertNotNull(extensionsConfig, "extensionsConfig");

            _player = player;

            _extensionFolders = extensionsConfig.ExtensionDirectories.
                Where(directory => !directory.FullName.EndsWith("_Files")).
                Select(directory => new ExtensionFolder(directory)).ToList();

            LoadApps();

            // At least one app has to be loaded.
            PreOrPostCondition.AssertInRange(1, Int32.MaxValue, Apps.Count(), "Apps.Count");
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Loads the apps.
        /// </summary>
        private void LoadApps()
        {
            foreach (var extensionFolder in _extensionFolders)
            {
                try
                {
                    ExtensionManager.Init(extensionFolder);
                }
                catch (Exception exception)
                {
                    var message = String.Format("Extension in folder {0} could not be loaded: {1}", extensionFolder.Directory.FullName, exception);
                    Logger.Get.Error(message);
                    throw new VideoWallException(message, exception);
                }

                extensionFolder.App.Activate(new ProductionVideoWallServiceProvider(extensionFolder, _player));
            }
        }

        #endregion
    }
}
