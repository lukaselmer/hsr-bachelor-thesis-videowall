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
using Microsoft.Kinect;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Implementation;

#endregion

namespace VideoWall.ServiceModels.Player.Interfaces
{
    /// <summary>
    ///   The player interface
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IPlayer
    {
        #region Properties

        /// <summary>
        ///   Gets or sets the skeleton.
        /// </summary>
        /// <value> The skeleton. </value>
        Skeleton Skeleton { get; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="Player" /> is playing.
        /// </summary>
        /// <value> <c>true</c> if playing; otherwise, <c>false</c> . </value>
        bool Playing { get; }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// </remarks>
        event EventHandler<SkeletonChangedEventArgs> SkeletonChanged;

        #endregion

        #region Methods

        /// <summary>
        ///   Starts the skeleton reader.
        /// </summary>
        void StartPlaying();

        /// <summary>
        ///   Stops the skeleton reader.
        /// </summary>
        void StopPlaying();

        #endregion
    }
}
