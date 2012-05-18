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
using System.Windows.Controls;

#endregion

namespace Interfaces
{
    public interface IApp
    {
        UserControl MainView { get; }
        string Name { get; }
        string DemomodeText { get; }

        /// <summary>
        /// Loads the app. At this place, the app can load application specific services.
        /// </summary>
        /// <param name="videoWallServiceProvider">The app info.</param>
        void Activate(IVideoWallServiceProvider videoWallServiceProvider);
    }
}

