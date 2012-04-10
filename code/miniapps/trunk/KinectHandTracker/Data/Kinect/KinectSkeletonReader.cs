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
                /*if (SkeletonsReady != null) */ SkeletonsReady(this, args);
            }
        }

        public void Start()
        {
            /*correction:Number = 0.5, jitterRadius:Number = 0.05,
                                                   maxDeviationRadius:Number = 0.04, prediction:Number = 0.5,
                                                   smoothing:Number = 0.5*/

            var parameters = _kinectSensor.SkeletonStream.SmoothParameters;
            parameters.Smoothing = 0.95f;
            _kinectSensor.SkeletonStream.Enable(parameters);
            _kinectSensor.Start();
        }

        public void Dispose()
        {
            _kinectSensor.SkeletonFrameReady -= OnKinectSensorOnSkeletonFrameReady;
            _kinectSensor.Stop();
        }
    }
}
