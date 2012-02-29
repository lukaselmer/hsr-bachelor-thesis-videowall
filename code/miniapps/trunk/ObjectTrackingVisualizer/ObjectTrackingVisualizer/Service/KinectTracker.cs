using System;
using Microsoft.Kinect;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectTracker : IDisposable
    {
        public delegate void SkeletonsReadyDelegate(Skeleton[] skeletons);

        public event SkeletonsReadyDelegate SkeletonsReady;

        public void OnSkeletonsReady(Skeleton[] skeletons)
        {
            var handler = SkeletonsReady;
            if (handler != null) handler(skeletons);
        }

        private Skeleton[] _skeletonData;

        private KinectSensor _sensor;

        public KinectTracker()
        {
            InitKinectSensor();
        }


        private void InitKinectSensor()
        {
            KinectSensor.KinectSensors.StatusChanged += (a, b) => { throw new Exception("Status of one Kinect unexpectedly changed!"); };
            if (KinectSensor.KinectSensors.Count != 1) { throw new Exception("There must be exactly one Kinect sensor attached to the PC"); }
            _sensor = KinectSensor.KinectSensors[0];

            _sensor.SkeletonStream.Enable();
            _skeletonData = new Skeleton[_sensor.SkeletonStream.FrameSkeletonArrayLength];

            _sensor.Start();

            _sensor.AllFramesReady += KinectAllFramesReady;
        }

        private void KinectAllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            using (var skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame == null) { return; } // imageFrame is null because the request did not arrive in time
                skeletonFrame.CopySkeletonDataTo(_skeletonData);
                OnSkeletonsReady(_skeletonData);
            }
        }

        public void Dispose()
        {
            _sensor.Stop();
            _sensor = null;
        }
    }

}