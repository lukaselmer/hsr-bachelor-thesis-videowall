#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Common;
using Interfaces;

#endregion

namespace Services.Apps
{
    /// <summary>
    ///   Controls the apps
    /// </summary>
    public class AppController
    {
        /// <summary>
        ///   Initializes the AppController
        /// </summary>
        public AppController()
        {
            ExtensionManager.Init(this);
            PreCondition.AssertNotNull(Apps, "Apps");
            // At least one app has to be loaded
            PreCondition.AssertInRange(1, Int32.MaxValue, Apps.Count, "Apps.Count");
        }

        /// <summary>
        ///   The video wall applications
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IApp> Apps { get; private set; }
    }
}