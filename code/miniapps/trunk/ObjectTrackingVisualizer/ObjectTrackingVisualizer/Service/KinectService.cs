using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Kinect;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectService : Notifier, IDisposable
    {
        public List<TrackedElement> Elements;
        private KinectSensor _sensor;

        private Skeleton[] _skeletonData;
        //public SkeletonFrame skeletonFrame;

        public KinectService()
        {
            Elements = new List<TrackedElement>();
            /*{
                new TrackedElement {Left = 10, Top = 100, Name = "one"},
                new TrackedElement {Left = 100, Top = 10, Name = "two"},
                new TrackedElement {Left = 300, Top = 200, Name = "three"},
                new TrackedElement {Left = 150, Top = 200, Name = "four"},
            };*/

            InitKinectSensor();


            KinectTracker = new KinectTracker(this);
            KinectSimulator = new KinectSimulator(KinectTracker);
        }

        private void InitKinectSensor()
        {
            KinectSensor.KinectSensors.StatusChanged += (a, b) => { throw new Exception("Status of one Kinect unexpectedly changed!"); };
            if (KinectSensor.KinectSensors.Count != 1) { throw new Exception("There must be exactly one Kinect sensor attached to the PC"); }
            _sensor = KinectSensor.KinectSensors[0];

            _sensor.SkeletonStream.Enable();
            _skeletonData = new Skeleton[_sensor.SkeletonStream.FrameSkeletonArrayLength];

            _sensor.Start();

            _sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(KinectAllFramesReady);
        }

        private void KinectAllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            using (var skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletonFrame.CopySkeletonDataTo(_skeletonData);
                    Log(_skeletonData);
                }
                else
                {
                    // imageFrame is null because the request did not arrive in time          }
                }
            }

        }

        private void Log(Skeleton[] skeletonData)
        {
            //Console.WriteLine(skeletonData);

            foreach (var skeleton in skeletonData)
            {
                if (skeleton.TrackingState == SkeletonTrackingState.NotTracked) continue;
                var trackingId = skeleton.TrackingId;
                Predicate<TrackedElement> cond = el => el.Id == trackingId;
                if (Elements.Exists(cond))
                {
                    TrackedElement e = Elements.Find(cond);
                    e.Left = 200 - (skeleton.Position.X * 400);
                    e.Top = 200 - (skeleton.Position.Y * 400);
                }
                else
                {
                    AddElement(new TrackedElement { Id = trackingId, Left = 0, Top = 0, Name = "" + trackingId });
                }

                //Console.WriteLine(skeleton.Position.X);
                //Console.WriteLine(skeleton.TrackingId);
            }
        }

        protected KinectSimulator KinectSimulator { get; set; }

        protected KinectTracker KinectTracker { get; set; }

        public void Dispose()
        {
            _sensor.Stop();
            _sensor = null;

            KinectSimulator.Dispose();
            KinectSimulator = null;
        }

        public void AddElement(TrackedElement trackedElement)
        {
            Elements.Add(trackedElement);
            Notify("Elements");
        }

        /*public TrackedElement FindxElement(Predicate<TrackedElement> cond)
        {
            var res = Elements.Find(cond);
            Notify("Elements");
            return res;
        }

        public bool ElementxExists(Predicate<TrackedElement> cond)
        {
            var res = Elements.Exists(cond);
            Notify("Elements");
            return res;
        }*/
    }
}