using System;
using System.IO;
using System.Linq;
using Kinect.Toolbox.Record;
using Microsoft.Kinect;
using Microsoft.Win32;

namespace Services.Recorder
{
    public class Recorder : Common.Notifier
    {
        private SkeletonRecorder _skeletonRecorder;
        private FileStream _recordStream;
        private bool _recording;
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

        public void StartRecording()
        {
            Recording = true;

            _skeletonRecorder = new SkeletonRecorder();
            var saveFileDialog = new SaveFileDialog { Title = "Select filename", Filter = "Replay files|*.replay" };
            if (saveFileDialog.ShowDialog() != true) { return; }
            var fileName = saveFileDialog.FileName;

            _recordStream = File.Create(fileName);
            _skeletonRecorder.Start(_recordStream);

            _kinectSensor = (from sensorToCheck in KinectSensor.KinectSensors
                             where sensorToCheck.Status == KinectStatus.Connected
                             select sensorToCheck).FirstOrDefault();


            if (_kinectSensor == null) throw new Exception("No ready Kinect connected!");

            _kinectSensor.SkeletonStream.Enable();
            _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Start();
        }

        private void OnKinectSensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs fArgs)
        {
            if (Recording) { _skeletonRecorder.Record(fArgs.OpenSkeletonFrame()); }
        }

        public void StopRecording()
        {
            Recording = false;
            _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Stop();
            _recordStream.Close();
            _recordStream.Dispose();
        }
    }
}
