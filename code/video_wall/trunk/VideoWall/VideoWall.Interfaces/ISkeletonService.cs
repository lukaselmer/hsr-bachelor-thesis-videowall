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

using System;

#endregion

namespace VideoWall.Interfaces
{
    /// <summary>
    ///   The skeleton service provides the skeletal tracking
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface ISkeletonService : IVideoWallService
    {
        #region Events

        /// <summary>
        ///   Occurs when skeleton changes.
        /// </summary>
        // ReSharper disable EventNeverSubscribedTo.Global
        // Since the skeleton service is used by extensions only, ReSharper thinks it is unused, which is wrong.
        event EventHandler<SkeletonChangedEventArgs> SkeletonChanged;

        // ReSharper restore EventNeverSubscribedTo.Global

        #endregion
    }
}
