using System;
using System.IO;
using System.Linq;
using Kinect.Toolbox.Record;
using Microsoft.Kinect;
using Microsoft.Win32;

namespace Services.Recorder
{
    public class KinectRecorder : Common.Notifier
    {
        private bool _recording;
        private SkeletonRecorder _skeletonRecorder;
        private FileStream _recordStream;
        private KinectSensor _kinectSensor;

        public bool Recording
        {
            get { return _recording; }
            private set
            {
                _recording = value;
                Notify("Recording");
            }
        }

        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs fArgs)
        {
            if (Recording) { _skeletonRecorder.Record(fArgs.OpenSkeletonFrame()); }
        }

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