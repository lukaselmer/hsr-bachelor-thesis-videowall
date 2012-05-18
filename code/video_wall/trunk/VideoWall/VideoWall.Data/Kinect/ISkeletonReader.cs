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

#endregion

namespace Data.Kinect
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public interface ISkeletonReader : IDisposable
    {
        /// <summary>
        ///   Occurs when [skeletons ready].
        /// </summary>
        event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady;

        /// <summary>
        ///   Starts the reading process
        /// </summary>
        void Start();
    }
}