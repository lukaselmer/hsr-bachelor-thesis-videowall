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
    ///   The file service provides a directory where an exension has read and write access.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IFileService : IVideoWallService
    {
        #region Properties

        /// <summary>
        ///   Gets the path to the resource directory
        /// </summary>
        // ReSharper disable UnusedMemberInSuper.Global
        // ReSharper disable UnusedMember.Global
        // Since this property is used by extensions only, ReSharper thinks it is unused, which is wrong.
        string ResourceDirectory { get; }
        // ReSharper restore UnusedMember.Global
        // ReSharper restore UnusedMemberInSuper.Global

        #endregion
    }
}
