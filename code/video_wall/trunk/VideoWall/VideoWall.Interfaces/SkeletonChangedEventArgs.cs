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

#endregion

namespace VideoWall.Interfaces
{
    /// <summary>
    ///   The skeleton changed event args
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class SkeletonChangedEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        ///   Gets the skeleton.
        /// </summary>
        public Skeleton Skeleton { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///   Initializes a new instance of the <see cref="SkeletonChangedEventArgs" /> class.
        /// </summary>
        /// <param name="skeleton"> The skeleton. </param>
        public SkeletonChangedEventArgs(Skeleton skeleton)
        {
            Skeleton = skeleton;
        }

        #endregion
    }
}
