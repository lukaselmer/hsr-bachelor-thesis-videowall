using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common;
using Interfaces;

namespace Services.Apps
{
    /// <summary>
    /// Controls the apps
    /// </summary>
    public class AppController
    {
        /// <summary>
        /// The video wall applications
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IApp> Apps { get; private set; }

        /// <summary>
        /// Initializes the AppController
        /// </summary>
        public AppController()
        {
            ExtensionManager.Init(this);
            PreCondition.AssertNotNull(Apps, "Apps");
            // At least one app has to be loaded
            PreCondition.AssertInRange(1, Int32.MaxValue, Apps.Count, "Apps.Count");
        }
    }
}
