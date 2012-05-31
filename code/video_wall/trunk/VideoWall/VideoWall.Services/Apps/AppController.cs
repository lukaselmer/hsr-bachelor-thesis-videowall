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
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using VideoWall.Common;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player;

#endregion

namespace VideoWall.ServiceModels.Apps
{
    /// <summary>
    ///   Controls the apps.
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong
    public class AppController
        // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly Player.Player _player;
        private readonly SkeletonService _skeletonService;

        #endregion

        #region Properties

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        [ImportMany(AllowRecomposition = false)]
        public ObservableCollection<IApp> Apps { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes the AppController.
        /// </summary>
        public AppController(Player.Player player)
        {
            _skeletonService = new SkeletonService(player);
            ExtensionManager.Init(this);
            PreOrPostCondition.AssertNotNull(Apps, "Apps");
            // At least one app has to be loaded
            PreOrPostCondition.AssertInRange(1, Int32.MaxValue, Apps.Count, "Apps.Count");
            LoadApps();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Loads the apps.
        /// </summary>
        private void LoadApps()
        {
            foreach (var app in Apps)
            {
                app.Activate(new ProductionVideoWallServiceProvider(app, _skeletonService));
            }
        }

        #endregion
    }
}
