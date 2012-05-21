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

using System.Windows.Controls;

#endregion

namespace VideoWall.Interfaces
{
    /// <summary>
    ///   This is the entry point for the framework. Every application must implement that interface.
    /// </summary>
    public interface IApp
    {
        /// <summary>
        ///   Gets the main view.
        /// </summary>
        UserControl MainView { get; }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///   Gets the demomode text.
        /// </summary>
        string DemomodeText { get; }

        /// <summary>
        ///   Loads the app. At this place, the app can load application specific services.
        /// </summary>
        /// <param name="videoWallServiceProvider"> The app info. </param>
        void Activate(IVideoWallServiceProvider videoWallServiceProvider);
    }
}