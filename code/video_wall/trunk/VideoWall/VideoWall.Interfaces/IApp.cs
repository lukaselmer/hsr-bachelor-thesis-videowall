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
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IApp
    {
        #region Properties

        /// <summary>
        ///   Gets the main view.
        /// </summary>
        /// <remarks>
        ///   If the application should run without System.Windwos, using UserControl is the wrong aproach. But since until now (05.06.2012) this is not the case, it would be overengineered if implemented otherwise.
        /// </remarks>
        UserControl MainView { get; }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///   Gets the demomode text.
        /// </summary>
        string DemomodeText { get; }

        #endregion

        #region Methods

        /// <summary>
        ///   Loads the app. At this place, the app can load application specific services.
        /// </summary>
        /// <param name="videoWallServiceProvider"> The app info. </param>
        // ReSharper disable UnusedParameter.Global
        // Used by extensions.
        void Activate(IVideoWallServiceProvider videoWallServiceProvider);
        // ReSharper restore UnusedParameter.Global

        #endregion
    }
}
