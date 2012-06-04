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
using VideoWall.Common;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Apps.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps.Implementation
{
    /// <summary>
    ///   Controls the apps.
    /// </summary>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class AppController : IAppController
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        private readonly Player.Player _player;
        private readonly List<ExtensionFolder> _extensionFolders;

        #endregion

        #region Properties

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        public IEnumerable<IApp> Apps { get { return _extensionFolders.Where(ef => ef.Loaded()).Select(ef => ef.App); } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes the AppController.
        /// </summary>
        public AppController(Player.Player player, ExtensionsConfig extensionsConfig)
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
                    throw new Exception(message, exception);
                }

                extensionFolder.App.Activate(new ProductionVideoWallServiceProvider(extensionFolder, _player));
            }
        }

        #endregion
    }
}
