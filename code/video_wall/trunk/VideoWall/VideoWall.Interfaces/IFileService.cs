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
    ///   The file service provides a directory where an exension has read and write access
    /// </summary>
    public interface IFileService : IVideoWallService
    {
        /// <summary>
        ///   Gets the path to the resource directory
        /// </summary>
        string ResourceDirectory { get; }
    }
}