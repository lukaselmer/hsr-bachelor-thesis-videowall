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
using System.Linq;
using Microsoft.Kinect;
using VideoWall.Data.Kinect.Implementation;
using VideoWall.Data.Kinect.Interfaces;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Player.Implementation
{
    /// <summary>
    ///   The player.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class Player : IPlayer
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The skeleton reader
        /// </summary>
        private readonly ISkeletonReader _skeletonReader;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the skeleton.
        /// </summary>
        /// <value> The skeleton. </value>
        public Skeleton Skeleton { get; private set; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="Player" /> is playing.
        /// </summary>
        /// <value> <c>true</c> if playing; otherwise, <c>false</c> . </value>
        public bool Playing { get; private set; }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// </remarks>
        public event EventHandler<SkeletonChangedEventArgs> SkeletonChanged = delegate { };

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="skeletonReader"> The skeleton reader. </param>
        public Player(ISkeletonReader skeletonReader)
        {
            Skeleton = new Skeleton();
            _skeletonReader = skeletonReader;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Starts the skeleton reader.
        /// </summary>
        public void StartPlaying()
        {
            Playing = true;
            _skeletonReader.SkeletonsReady += OnKinectSensorOnSkeletonFrameReady;
            _skeletonReader.Start();
        }

        /// <summary>
        ///   Stops the skeleton reader.
        /// </summary>
        public void StopPlaying()
        {
            Playing = false;
            _skeletonReader.SkeletonsReady -= OnKinectSensorOnSkeletonFrameReady;
            // _skeletonReader.Dispose(); NOTE: implementation of IDisposable pattern isn't correct yet
        }

        /// <summary>
        ///   Called when [kinect sensor on skeleton frame ready].
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="SkeletonsReadyEventArgs" /> instance containing the event data. </param>
        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonsReadyEventArgs e)
        {
            if (!Playing) return;

            Skeleton = (from skeleton in e.Skeletons
                        where skeleton.TrackingState == SkeletonTrackingState.Tracked
                        select skeleton).FirstOrDefault();
            SkeletonChanged(this, new SkeletonChangedEventArgs(Skeleton));
        }

        #endregion
    }
}
