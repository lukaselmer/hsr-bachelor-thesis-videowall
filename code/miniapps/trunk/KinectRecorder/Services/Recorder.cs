using System.IO;
using System.Windows.Input;
using Kinect.Toolbox.Record;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Kinect;
using Microsoft.Win32;

namespace Services
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

            _kinectSensor = KinectSensor.KinectSensors[0];
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
            _kinectSensor.Stop();
            Recording = false;
            _recordStream.Close();
            _recordStream.Dispose();
        }
    }
}
