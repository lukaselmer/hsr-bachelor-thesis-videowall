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
        /// <summary>
        ///   Gets an implementation of the interface <typeparam name="T"> </typeparam> which is provided by the video wall
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <returns> </returns>
        T GetExtension<T>() where T : IVideoWallService;
    }
}