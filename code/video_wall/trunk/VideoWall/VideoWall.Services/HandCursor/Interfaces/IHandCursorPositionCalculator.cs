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
using System.Collections.Generic;
using System.Windows;
using Microsoft.Kinect;
using VideoWall.ServiceModels.HandCursor.Implementation;

#endregion

namespace VideoWall.ServiceModels.HandCursor.Interfaces
{
    /// <summary>
    ///   The hand cursor position calculator interface
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IHandCursorPositionCalculator
    {
        #region Events

        /// <summary>
        ///   Occurs when the hand changed.
        /// </summary>
        event EventHandler<HandChangedEventArgs> HandChanged;

        #endregion

        #region Methods

        /// <summary>
        ///   Calculates the hand cursor position from multiple skeletons (with smoothing).
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="skeletonHistory"> The skeleton history. </param>
        /// <param name="latestSkeleton"> The latest skeleton. </param>
        /// <returns> </returns>
        Point CalculatePositionFromSkeletons(Size size, Queue<Skeleton> skeletonHistory, Skeleton latestSkeleton);

        #endregion
    }
}
