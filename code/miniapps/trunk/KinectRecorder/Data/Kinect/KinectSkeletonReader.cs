using System;
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
            _kinectSensor = KinectSensor.KinectSensors[0];
            _kinectSensor.SkeletonStream.Enable();
            _kinectSensor.SkeletonFrameReady += OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Start();
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

        public void Dispose()
        {
            _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Stop();
        }
    }
}
