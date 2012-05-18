#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using Microsoft.Kinect;

#endregion

namespace VideoWall.Data.Kinect
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class SkeletonsReadyEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="SkeletonsReadyEventArgs" /> class.
        /// </summary>
        /// <param name="skeletons"> The skeletons. </param>
        public SkeletonsReadyEventArgs(Skeleton[] skeletons)
        {
            Skeletons = skeletons;
        }

        /// <summary>
        ///   Gets the skeletons.
        /// </summary>
        public Skeleton[] Skeletons { get; private set; }
    }
}