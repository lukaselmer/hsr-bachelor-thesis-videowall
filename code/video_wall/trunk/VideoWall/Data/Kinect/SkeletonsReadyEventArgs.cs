using System;
using Microsoft.Kinect;

namespace Data.Kinect
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class SkeletonsReadyEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the skeletons.
        /// </summary>
        public Skeleton[] Skeletons { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkeletonsReadyEventArgs"/> class.
        /// </summary>
        /// <param name="skeletons">The skeletons.</param>
        public SkeletonsReadyEventArgs(Skeleton[] skeletons)
        {
            Skeletons = skeletons;
        }
    }
}
