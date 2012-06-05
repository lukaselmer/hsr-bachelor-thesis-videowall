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
using System.IO;
using Kinect.Toolbox.Record;
using VideoWall.Data.Kinect.Interfaces;

#endregion

namespace VideoWall.Data.Kinect.Implementation
{
    /// <summary>
    ///   This class is used for the development only.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class FileSkeletonReader : ISkeletonReader
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        /// <summary>
        /// The skeleton replay.
        /// </summary>
        private readonly SkeletonReplay _skeletonReplay;

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when the skeletons are ready.
        /// </summary>
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady = delegate { };

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="FileSkeletonReader" /> class.
        /// </summary>
        /// <param name="kinectReplayFile"> The kinect replay file. </param>
        public FileSkeletonReader(KinectReplayFile kinectReplayFile)
        {
            using (var stream = File.OpenRead(kinectReplayFile.Path))
            {
                _skeletonReplay = new SkeletonReplay(stream);
                _skeletonReplay.SkeletonFrameReady += OnSkeletonFrameReady;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Starts the reading process
        /// </summary>
        public void Start()
        {
            _skeletonReplay.Start();
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _skeletonReplay.SkeletonFrameReady -= OnSkeletonFrameReady;
            _skeletonReplay.Stop();
        }

        /// <summary>
        ///   Called when [skeleton frame ready].
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see>
        ///                        <cref>Kinect.Toolbox.Record.ReplaySkeletonFrameReadyEventArgs</cref>
        ///                      </see> instance containing the event data. </param>
        private void OnSkeletonFrameReady(object sender, ReplaySkeletonFrameReadyEventArgs e)
        {
            SkeletonsReady(this, new SkeletonsReadyEventArgs(e.SkeletonFrame.Skeletons));
        }

        #endregion
    }
}
