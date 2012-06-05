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
using VideoWall.Data.Kinect.Implementation;

#endregion

namespace VideoWall.Data.Kinect.Interfaces
{
    /// <summary>
    ///   The skeleton reader interface is used for different skeleton readers like
    ///   a skeleton reader which reads from the kinect (for production and development) and a skeleton
    ///   reader which reads from a file (for development only)
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface ISkeletonReader
    {
        /// <summary>
        ///   Occurs when the skeletons are ready.
        /// </summary>
        event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady;

        /// <summary>
        ///   Starts the reading process.
        /// </summary>
        void Start();
    }
}
