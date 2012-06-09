﻿#region Header

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
using VideoWall.Data.Kinect.Interfaces;

#endregion

namespace VideoWall.Data.Kinect.Implementation
{
    /// <summary>
    ///   The KinectSkeletonReader. Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    internal class KinectSkeletonReader : ISkeletonReader
    {
        #region Declarations

        private readonly KinectSensor _kinectSensor;
        private Skeleton[] _skeletons;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the skeletons are ready.
        /// </summary>
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="KinectSkeletonReader" /> class. Checkes if a kinect sensor is conneted, throws excpetion otherwise.
        /// </summary>
        public KinectSkeletonReader()
        {
            _kinectSensor = (from sensorToCheck in KinectSensor.KinectSensors
                             where sensorToCheck.Status == KinectStatus.Connected
                             select sensorToCheck).FirstOrDefault();

            if (_kinectSensor == null) throw new Exception("No ready Kinect connected!");

            _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Starts the reading process
        /// </summary>
        public void Start()
        {
            _kinectSensor.SkeletonStream.Enable();
            _kinectSensor.Start();
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Stop();
        }

        /// <summary>
        ///   Called when [kinect sensor on skeleton frame ready].
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="Microsoft.Kinect.SkeletonFrameReadyEventArgs" /> instance containing the event data. </param>
        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (var frame = e.OpenSkeletonFrame())
            {
                if (frame == null) return;
                _skeletons = new Skeleton[frame.SkeletonArrayLength];
                frame.CopySkeletonDataTo(_skeletons);
                var args = new SkeletonsReadyEventArgs(_skeletons);
                SkeletonsReady(this, args);
            }
        }

        #endregion
    }
}