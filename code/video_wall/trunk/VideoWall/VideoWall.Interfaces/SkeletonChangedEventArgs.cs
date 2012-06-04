using System;
using Microsoft.Kinect;

namespace VideoWall.Interfaces
{
    /// <summary>
    /// The skeleton changed event args
    /// </summary>
    public class SkeletonChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the skeleton.
        /// </summary>
        public Skeleton Skeleton { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkeletonChangedEventArgs"/> class.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        public SkeletonChangedEventArgs(Skeleton skeleton)
        {
            Skeleton = skeleton;
        }
    }
}