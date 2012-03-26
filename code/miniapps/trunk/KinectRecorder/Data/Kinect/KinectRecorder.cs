using System;
using System.IO;
using System.Linq;
using Kinect.Toolbox.Record;
using Microsoft.Kinect;
using Microsoft.Win32;

namespace Services.Recorder
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class KinectRecorder : Common.Notifier
    {
        private bool _recording;
        private SkeletonRecorder _skeletonRecorder;
        private FileStream _recordStream;
        private KinectSensor _kinectSensor;

        /// <summary>
        /// Gets a value indicating whether this <see cref="KinectRecorder"/> is recording.
        /// </summary>
        /// <value>
        ///   <c>true</c> if recording; otherwise, <c>false</c>.
        /// </value>
        public bool Recording
        {
            get { return _recording; }
            private set
            {
                _recording = value;
                Notify("Recording");
            }
        }

        /// <summary>
        /// Called when [kinect sensor on skeleton frame ready].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="fArgs">The <see cref="Microsoft.Kinect.SkeletonFrameReadyEventArgs"/> instance containing the event data.</param>
        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs fArgs)
        {
            if (Recording) { _skeletonRecorder.Record(fArgs.OpenSkeletonFrame()); }
        }

        /// <summary>
        /// Starts the recording, saves the file to the specified path.
        /// Checkes if a kinect sensor is conneted, throws excpetion otherwise.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        public void Start(string pathToFile)
        {
            lock (this)
            {
                _skeletonRecorder = new SkeletonRecorder();

                Recording = true;

                _recordStream = File.Create(pathToFile);
                _skeletonRecorder.Start(_recordStream);

                _kinectSensor = (from sensorToCheck in KinectSensor.KinectSensors
                                 where sensorToCheck.Status == KinectStatus.Connected
                                 select sensorToCheck).FirstOrDefault();

                if (_kinectSensor == null) throw new Exception("No ready Kinect connected!");

                _kinectSensor.SkeletonStream.Enable();
                _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
                _kinectSensor.Start();
            }
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                if (!Recording) return;
                Recording = false;
                _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
                _skeletonRecorder.Stop();
                _kinectSensor.Stop();
                _recordStream.Close();
                _recordStream.Dispose();
            }
        }
    }
}