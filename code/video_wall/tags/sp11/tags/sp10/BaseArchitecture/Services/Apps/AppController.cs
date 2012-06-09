using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Interfaces;

namespace Services.Apps
{
    /// <summary>
    /// Controls the apps
    /// </summary>
    public class AppController
    {
        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IApp> Apps { get; private set; }

        /// <summary>
        /// TODO
        /// </summary>
        public AppController()
        {
            ExtensionManager.Init(this);
        }
    }
}
