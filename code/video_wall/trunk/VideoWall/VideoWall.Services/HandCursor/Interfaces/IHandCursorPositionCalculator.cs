using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Kinect;
using VideoWall.ServiceModels.HandCursor.Implementation;

namespace VideoWall.ServiceModels.HandCursor.Interfaces
{
    /// <summary>
    /// The hand cursor position calculator interface
    /// </summary>
    public interface IHandCursorPositionCalculator
    {
        /// <summary>
        /// Calculates the hand cursor position from multiple skeletons (with smoothing).
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="skeletonHistory">The skeleton history.</param>
        /// <param name="latestSkeleton">The latest skeleton.</param>
        /// <returns></returns>
        Point CalculatePositionFromSkeletons(Size size, Queue<Skeleton> skeletonHistory, Skeleton latestSkeleton);

        /// <summary>
        /// Occurs when the hand changed.
        /// </summary>
        event EventHandler<HandChangedEventArgs> HandChanged;
    }
}