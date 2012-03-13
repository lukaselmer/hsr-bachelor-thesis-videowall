using System;
using System.Linq;
using Microsoft.Kinect;

namespace Data.Kinect
{
    class KinectSkeletonReader : ISkeletonReader
    {
        private readonly KinectSensor _kinectSensor;
        private Skeleton[] _skeletons;
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady;

        public KinectSkeletonReader()
        {
            _kinectSensor = (from sensorToCheck in KinectSensor.KinectSensors
                             where sensorToCheck.Status == KinectStatus.Connected
                             select sensorToCheck).FirstOrDefault();

            if (_kinectSensor == null) throw new Exception("No ready Kinect connected!");

            _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
        }

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

        public void Start()
        {
            _kinectSensor.SkeletonStream.Enable();
            _kinectSensor.Start();
        }

        public void Dispose()
        {
            _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Stop();
        }
    }
}
