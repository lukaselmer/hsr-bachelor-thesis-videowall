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

namespace VideoWall.Data.Kinect.Interfaces
{
    /// <summary>
    ///   The skeletons ready event arg contains multiple skeletons which are extracted already.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class SkeletonsReadyEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        ///   Gets the skeletons.
        /// </summary>
        public Skeleton[] Skeletons { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="SkeletonsReadyEventArgs" /> class.
        /// </summary>
        /// <param name="skeletons"> The skeletons. </param>
        public SkeletonsReadyEventArgs(Skeleton[] skeletons)
        {
            Skeletons = skeletons;
        }

        #endregion
    }
}
