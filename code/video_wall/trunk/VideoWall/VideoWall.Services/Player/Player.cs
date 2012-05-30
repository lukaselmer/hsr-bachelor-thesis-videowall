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

using System.ComponentModel;
using System.Linq;
using Microsoft.Kinect;
using VideoWall.Common;
using VideoWall.Data.Kinect;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Player
{
    /// <summary>
    ///   The Player. Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong
    public class Player
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly ISkeletonReader _skeletonReader;
        //private FileStream _recordStream;
        //private KinectSensor _kinectSensor;

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
        public event SkeletonChangedEvent PropertyChanged = delegate {};

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

            /*_skeletonRecorder = new SkeletonRecorder();
            var saveFileDialog = new SaveFileDialog { Title = "Select filename", Filter = "Replay files|*.replay" };
            if (saveFileDialog.ShowDialog() != true) { return; }
            var fileName = saveFileDialog.FileName;

            _recordStream = File.Create(fileName);
            _skeletonRecorder.Start(_recordStream);

            _kinectSensor = KinectSensor.KinectSensors[0];
            _kinectSensor.SkeletonStream.Enable();
            _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Start();*/
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
            PropertyChanged(this, new SkeletonChangedEventArgs(Skeleton));
        }

        /// <summary>
        ///   Stops the skeleton reader.
        /// </summary>
        public void StopPlaying()
        {
            Playing = false;
            _skeletonReader.SkeletonsReady -= OnKinectSensorOnSkeletonFrameReady;
            _skeletonReader.Dispose();
        }

        #endregion
    }
}