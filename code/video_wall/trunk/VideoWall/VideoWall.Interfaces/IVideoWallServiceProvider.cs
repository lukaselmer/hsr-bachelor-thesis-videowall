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

namespace VideoWall.Interfaces
{
    /// <summary>
    ///   Provides services for the video wall, like hand tracking, skeleton tracking or a file service
    /// </summary>
    public interface IVideoWallServiceProvider
    {
        #region Methods

        /// <summary>
        /// Gets an implementation of the interface which is provided by the video wall
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        // ReSharper disable UnusedMember.Global
        // This method is used by the extensions. Since they are not in this project, ReSharper cannot know that this method is used.
        T GetExtension<T>() where T : IVideoWallService;
        // ReSharper restore UnusedMember.Global

        #endregion
    }
}
