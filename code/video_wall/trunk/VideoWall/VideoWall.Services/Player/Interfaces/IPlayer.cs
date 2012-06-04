using System;
using Microsoft.Kinect;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Implementation;

namespace VideoWall.ServiceModels.Player.Interfaces
{
    /// <summary>
    /// The player interface
    /// </summary>
    public interface IPlayer
    {
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

        /// <summary>
        ///   Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// </remarks>
        event EventHandler<SkeletonChangedEventArgs> SkeletonChanged;

        /// <summary>
        ///   Starts the skeleton reader.
        /// </summary>
        void StartPlaying();

        /// <summary>
        ///   Stops the skeleton reader.
        /// </summary>
        void StopPlaying();
    }
}