using System;
using System.IO;
using System.Linq;
using Data;
using Data.Kinect;
using Kinect.Toolbox.Record;
using Microsoft.Kinect;
using Microsoft.Practices.Unity;
using Microsoft.Win32;

namespace Services.Player
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class Player : Common.Notifier
    {
        private readonly ISkeletonReader _skeletonReader;
        //private FileStream _recordStream;
        private bool _playing;
        public Skeleton Skeleton { get; set; }
        //private KinectSensor _kinectSensor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="skeletonReader">The skeleton reader.</param>
        public Player(ISkeletonReader skeletonReader)
        {
            Skeleton = new Skeleton();
           _skeletonReader = skeletonReader;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Player"/> is playing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if playing; otherwise, <c>false</c>.
        /// </value>
        public bool Playing
        {
            get { return _playing; }
            private set
            {
                _playing = value;
                Notify("Playing");
            }
        }

        /// <summary>
        /// Starts the skeleton reader.
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
        /// Called when [kinect sensor on skeleton frame ready].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Data.SkeletonsReadyEventArgs"/> instance containing the event data.</param>
        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonsReadyEventArgs e)
        {
            if (!Playing) return;

            Skeleton = (from skeleton in e.Skeletons
                        where skeleton.TrackingState == SkeletonTrackingState.Tracked
                        select skeleton).FirstOrDefault();
            Notify("Skeleton");
        }

        /// <summary>
        /// Stops the skeleton reader.
        /// </summary>
        public void StopPlaying()
        {
            Playing = false;
            _skeletonReader.SkeletonsReady -= OnKinectSensorOnSkeletonFrameReady;
            _skeletonReader.Dispose();
        }
    }
}
